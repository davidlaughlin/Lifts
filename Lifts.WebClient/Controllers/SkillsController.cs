using System;
using System.Collections.Generic;
using System.Linq;
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

        private IEnumerable<SkillViewModel> GetSkills()
        {
            List<SkillViewModel> skills = new List<SkillViewModel>
            {
                new SkillViewModel("Cardiovascular / Respiratory Endurance", "The ability of body systems to gather, process, and deliver oxygen.", 14),
                new SkillViewModel("Stamina", "The ability of body systems to process, deliver, store, and utilize energy.", 35),
                new SkillViewModel("Strength", "The ability of a muscular unit, or combination of muscular units, to apply force.", 45),
                new SkillViewModel("Flexibility", "The ability to maximize the range of motion at a given joint.", 29),
                new SkillViewModel("Power", "The ability of a muscular unit, or combination of muscular units, to apply maximum force in minimum time.", 65),
                new SkillViewModel("Speed", "The ability to minimize the time cycle of a repeated movement.", 9),
                new SkillViewModel("Coordination", "The ability to combine several distinct movement patterns into a singular distinct movement.", 3),
                new SkillViewModel("Agility", "The ability to minimize transition time from one movement pattern to another.", 100),
                new SkillViewModel("Balance", "The ability to control the placement of the bodies center of gravity in relation to its support base.", 82),
                new SkillViewModel("Accuracy", "The ability to control movement in a given direction or at a given intensity.", 99)
            };


            return skills;
        }

    }
}