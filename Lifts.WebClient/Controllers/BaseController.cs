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
        protected new ViewResult View(object model)
        {
            IHtmlString payload = SerializeObject(model);
            return base.View(payload);
        }

        protected IHtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
                jsonWriter.QuoteName = false;   // We don't want quotes around object names
                serializer.Serialize(jsonWriter, value);

                return new HtmlString(stringWriter.ToString());
            }
        }

    }
}