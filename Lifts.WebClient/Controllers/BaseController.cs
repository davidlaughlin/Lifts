using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lifts.Data;
using Lifts.Data.Repository.UnitsOfWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lifts.WebClient.Controllers
{
    public abstract class BaseController : Controller
    {
    }
}