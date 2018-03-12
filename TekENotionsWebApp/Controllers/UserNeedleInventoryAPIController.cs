using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp.Controllers
{
    public class UserNeedleInventoryAPIController : ApiController
    {
        private TekENotionsEntities db = new TekENotionsEntities();

        // GET api/<controller>
        public IEnumerable<UserNeedleInventory> Get()
        {
            return db.UserNeedleInventories;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserNeedleInventory item)
        {
            var test = "fail";
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var desc = db.NeedleDescriptionLookups
                   .Where(b => b.systemDescription == item.systemName)
                   .FirstOrDefault();


               
                if (desc!=null)
                {
                    item.ravelryId = desc.id;
                    item.ravelryName = desc.ravelryDescription;
                }
                item = db.UserNeedleInventories.Add(item);
                db.SaveChanges();
                response = Request.CreateResponse<UserNeedleInventory>(HttpStatusCode.Created, item);

                string uri = Url.Link("DefaultApi", new { id = item.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
          
            catch(Exception ex)
            {
                test = ex.Message;
            }
            response.Headers.Location = new Uri(test);
            return response ;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]UserNeedleInventory inventory)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}