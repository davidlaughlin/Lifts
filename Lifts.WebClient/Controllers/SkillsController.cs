using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lifts.Data;
using Lifts.Data.DomainModel;
using Lifts.Data.Repositories;
using Lifts.WebClient.ActionResults;
using Lifts.WebClient.ViewModels;

namespace Lifts.WebClient.Controllers
{
    public class SkillsController : BaseController
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IAthleteRepository _athleteRepository;

        public SkillsController(ISkillRepository skillRepository, IAthleteRepository athleteRepository)
        {
            _skillRepository = skillRepository;
            _athleteRepository = athleteRepository;
        }

        public ActionResult Index(int athleteId)
        {
            Athlete athlete = _athleteRepository.Find(each => each.Id == athleteId).FirstOrDefault();
            if (athlete == null)
            {
                return new HttpNotFoundResult();
            }

            SkillProgressCalculator calculator = new SkillProgressCalculator(_skillRepository.All());
            IEnumerable<SkillProgressViewModel> viewModel = calculator.Calculate(athlete).Select(each => new SkillProgressViewModel(each));

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Detail(int athleteId, string name)
        {
            List<FitnessTestProgressViewModel> viewModel = new List<FitnessTestProgressViewModel>();
            Skill skill = _skillRepository.Find(each => each.Name == name).FirstOrDefault();
            Athlete athlete = _athleteRepository.Find(each => each.Id == athleteId).FirstOrDefault();

            if (skill == null || athlete == null)
            {
                return new HttpNotFoundResult();
            }

            foreach (FitnessTest fitnessTest in skill.FitnessTests)
            {
                if (athlete.AthleteFitnessTests.Any(each => each.FitnessTestId == fitnessTest.Id))
                {
                    bool completed = athlete.AthleteFitnessTests.First(each => each.FitnessTestId == fitnessTest.Id).Completed;
                    viewModel.Add(new FitnessTestProgressViewModel(fitnessTest.Id, skill.Name, fitnessTest.Name, completed));
                }
                else
                {
                    viewModel.Add(new FitnessTestProgressViewModel(fitnessTest.Id, skill.Name, fitnessTest.Name, false));
                }

            }

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(viewModel);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(int athleteId, FitnessTestProgressViewModel fitnessTest)
        {
            Athlete athlete = _athleteRepository.Find(each => each.Id == athleteId).FirstOrDefault();
            if (athlete != null)
            {
                AthleteFitnessTest athleteFitnessTest = athlete.AthleteFitnessTests.FirstOrDefault(each => each.FitnessTestId == fitnessTest.Id);
                if (athleteFitnessTest != null)
                {
                    athleteFitnessTest.Completed = fitnessTest.Completed;
                }
                else
                {
                    athleteFitnessTest = new AthleteFitnessTest();
                    athleteFitnessTest.Athlete = athlete;
                    athleteFitnessTest.FitnessTestId = fitnessTest.Id;
                    athleteFitnessTest.Completed = fitnessTest.Completed;
                    athlete.AthleteFitnessTests.Add(athleteFitnessTest);
                }

                return new JsonNetResult(new { success = true });
            }
            
            return new JsonNetResult(new { success = false });
        }
    }
}