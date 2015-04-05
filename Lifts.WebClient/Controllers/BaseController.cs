using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lifts.Data;
using Lifts.Data.Repository.UnitsOfWork;
using Lifts.WebClient.App_Start;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lifts.WebClient.Controllers
{
    public abstract class BaseController : Controller
    {

        protected override void Dispose(bool disposing)
        {
            IUnitOfWork unitOfWork = UnityConfig.GetConfiguredContainer().Resolve(typeof(IUnitOfWork)) as IUnitOfWork;

            unitOfWork.SaveChanges();
            //unitOfWork.Dispose(); // Will unity do this?
        }

    }
}