using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TekENotionsWebApp.Components;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp.Controllers
{
    [RoutePrefix("api/patternApi")]
    public class PatternAPIController : ApiController
    {
        private TekENotionsEntities db = new TekENotionsEntities();
        private PatternSearch SearchEntity = new PatternSearch();
        public List<pattern> Patterns { get; set; }
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result;

           
            if (db.patterns.Count() > 0)
            {
                result = Ok(db.patterns.Where(x => x.id < 50));
            }
           
            else
            {
                result = NotFound();
            }
            

            return result;
        }

        [Route("Search")]
        [HttpPost()]
        public IHttpActionResult Search([FromBody]PatternSearch search)
        {
            IHttpActionResult result;

            if (db.patterns.Count() > 0)
            {
                result = Ok(db.patterns.Where(x => x.free == true  && x.name.Contains(search.PatternName)));
            }

            else
            {
                result = NotFound();
            }


            return result;
        }

        public void Search()
        {
           
          
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