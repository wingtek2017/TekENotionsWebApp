using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp.Controllers
{
    [RoutePrefix("api/NeedleApi")]
    public class NeedleTypeAPIController : ApiController
    {
        private TekENotionsEntities db = new TekENotionsEntities();
        // GET api/<controller>
        [HttpPost()]
        [Route("SearchNeedlesTypes")]
        public IHttpActionResult Get()
        {
            IHttpActionResult result;

            if (db.needle_types.Count() > 0)
            {
                result = Ok(db.needle_types.Where(x => x.type_name == "circular").Where(y => y.needle_size_id == 8));
             
            }

            else
            {
                result = NotFound();
            }


            return result;
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}