using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lifts.WebClient.ActionResults
{
    public class JsonNetResult : ActionResult
    {
        private const string ContentType = "application/json";

        private readonly object _data;
        private readonly Formatting _formatting;
        private readonly JsonSerializerSettings _serializerSettings;

        public object Data => _data;

        public JsonNetResult(object data)
        {
            _data = data;
            _formatting = Formatting.None;
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = ContentType;

            if (_data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = _formatting };
                JsonSerializer serializer = JsonSerializer.Create(_serializerSettings);

                serializer.Serialize(writer, _data);
                writer.Flush();
            }
        }
    }
}