using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Lifts.Data;
using Lifts.Data.Repositories;
using Lifts.Data.Repository.UnitsOfWork;
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

        public ActionResult Index()
        {
            IEnumerable<SkillProgressViewModel> viewModel = GetSkills();

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Detail(string name)
        {
            IEnumerable<FitnessTestViewModel> viewModel;
            SkillProgressViewModel skill = GetSkills().FirstOrDefault(each => each.Name == name);

            if (skill == null)
            {
                return new HttpNotFoundResult();
            }

            viewModel = GetFitnessTests(name);

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(viewModel);
            }

            return View(viewModel);
        }


        private IEnumerable<SkillProgressViewModel> GetSkills()
        {
            List<SkillProgressViewModel> skills = new List<SkillProgressViewModel>();

            Athlete athlete = _athleteRepository.Find(each => each.LastName == "Laughlin").FirstOrDefault();
            if (athlete == null)
            {
                return null;
            }

            foreach (Skill skill in _skillRepository.All())
            {
                IEnumerable<AthleteFitnessTest> fitnessTests = athlete.AthleteFitnessTests.Where(fitnessTest => fitnessTest.FitnessTest.Skill == skill);
                skills.Add(new SkillProgressViewModel(skill.Id, skill.Name, skill.Description, fitnessTests.Count()*10)
                {
                    AthleteName = string.Format("{0} {1}", athlete.FirstName, athlete.LastName)
                });
            };

            return skills;
        }

        private IEnumerable<FitnessTestViewModel> GetFitnessTests(string name)
        {
            List<FitnessTestViewModel> tests = new List<FitnessTestViewModel>
            {
                new FitnessTestViewModel(0, "Sit and Reach", false),
                new FitnessTestViewModel(1, "V-Sit", false),
                new FitnessTestViewModel(2, "Groin Flexibility", true),
                new FitnessTestViewModel(3, "Calf Muscle Flexibility", true),
                new FitnessTestViewModel(4, "Trunk Rotation", false),
                new FitnessTestViewModel(5, "Shoulder Flex", false),
                new FitnessTestViewModel(6, "Shoulder Circumduction", false),
                new FitnessTestViewModel(7, "Shoulder Rotation", true),
                new FitnessTestViewModel(8, "Back Scratch", true),
                new FitnessTestViewModel(9, "Shoulder Stretch", false),
            };


            return tests;
        }


    }
}