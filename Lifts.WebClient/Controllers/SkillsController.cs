using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Lifts.WebClient.ActionResults;
using Lifts.WebClient.ViewModels;

namespace Lifts.WebClient.Controllers
{
    public class SkillsController : BaseController
    {
        public ActionResult Index()
        {
            IEnumerable<SkillViewModel> viewModel = GetSkills();

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Detail(string name)
        {
            IEnumerable<FitnessTestViewModel> viewModel;
            SkillViewModel skill = GetSkills().FirstOrDefault(each => each.Name == name);
            
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


        private IEnumerable<SkillViewModel> GetSkills()
        {
            List<SkillViewModel> skills = new List<SkillViewModel>
            {
                new SkillViewModel(0, "Cardiovascular / Respiratory Endurance", "The ability of body systems to gather, process, and deliver oxygen.", 14),
                new SkillViewModel(1, "Stamina", "The ability of body systems to process, deliver, store, and utilize energy.", 35),
                new SkillViewModel(2, "Strength", "The ability of a muscular unit, or combination of muscular units, to apply force.", 45),
                new SkillViewModel(3, "Flexibility", "The ability to maximize the range of motion at a given joint.", 29),
                new SkillViewModel(4, "Power", "The ability of a muscular unit, or combination of muscular units, to apply maximum force in minimum time.", 65),
                new SkillViewModel(5, "Speed", "The ability to minimize the time cycle of a repeated movement.", 9),
                new SkillViewModel(6, "Coordination", "The ability to combine several distinct movement patterns into a singular distinct movement.", 3),
                new SkillViewModel(7, "Agility", "The ability to minimize transition time from one movement pattern to another.", 100),
                new SkillViewModel(8, "Balance", "The ability to control the placement of the bodies center of gravity in relation to its support base.", 82),
                new SkillViewModel(9, "Accuracy", "The ability to control movement in a given direction or at a given intensity.", 99)
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