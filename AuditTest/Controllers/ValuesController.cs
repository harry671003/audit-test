using Microsoft.Partner.Auditing.Common.Models;
using Microsoft.Partner.Auditing.WebApiFilter;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuditTest.Controllers
{
    public class ValuesController : ApiController, IAuditable
    {
        public AuditExtendedProperties AuditRecord { get; set; }

        // GET api/values
        [Audit("ResourceType", "ResourceSubType", null)]
        public IEnumerable<string> Get()
        {
            AuditRecord = new AuditExtendedProperties
            {
                EntityId = Guid.NewGuid().ToString(),
                EntityName = "Enitty23",
                OldValue = JObject.FromObject(new
                {
                    hello = "test23",
                    i = 2,
                    hello2 = true,
                    j = 56
                }),
                PartnerId = Guid.NewGuid().ToString(),
                PartnerName = "Harry23",
                SourceSystem = "SourceSystem23",
                CustomData = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("k1", "v12323"),
                    new KeyValuePair<string, string>("k2", "v223")
                },
                SessionId = Guid.NewGuid().ToString(),
                CorrelationId = Guid.NewGuid().ToString()
            };

            return new string[] { "value1", "value2" };
        }

        [Audit("ResourceType", "ResourceSubTtype", "OperationTypeOverride")]
        public string Get(int id)
        {
            throw new Exception("hello exception");
            //AuditRecord = new AuditExtendedProperties
            //{
            //    EntityId = Guid.NewGuid().ToString(),
            //    EntityName = "Enitty",
            //    OldValue = JObject.FromObject(new
            //    {
            //        hello = "test"
            //    }),
            //    PartnerId = Guid.NewGuid().ToString(),
            //    PartnerName = "Harry",
            //    SourceSystem = "SourceSystem",
            //    CustomData = new List<KeyValuePair<string, string>>
            //    {
            //        new KeyValuePair<string, string>("k1", "v1"),
            //        new KeyValuePair<string, string>("k2", "v2")
            //    },
            //    SessionId = Guid.NewGuid().ToString(),
            //    CorrelationId = Guid.NewGuid().ToString()
            //};

            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
