using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lifts.WebClient.Controllers
{
    public class SkillsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}