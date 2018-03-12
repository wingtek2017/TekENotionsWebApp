using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp.Controllers
{
    public class needle_typesController : ApiController
    {
        private TekENotionsEntities db = new TekENotionsEntities();

        // GET: api/needle_types
        public IQueryable<needle_types> Getneedle_types()
        {

            return db.needle_types;
        }

        // GET: api/needle_sizes/5
        [Route("api/needle_sizes_byType/{type}")]
        [ResponseType(typeof(needle_sizes))]
        public IQueryable<string> Getneedle_sizes_byType(string type)
        {
            IQueryable<string> data = from nt in db.needle_types
                                      join ns in db.needle_sizes
                                          on nt.needle_size_id equals ns.id
                                      where nt.type_name == type
                                      where ns.us != null
                                      select (ns.us + " / " + ns.metric);

            
            return data.Distinct();


        }

        [Route("api/distinct_needle_types")]
        public IQueryable<string> GetDistinctneedle_types()
        {
           

            return db.needle_types.Select(m => m.type_name).Distinct();

        }


        // GET: api/needle_types/5
        [ResponseType(typeof(needle_types))]
        public IHttpActionResult Getneedle_types(int id)
        {
            needle_types needle_types = db.needle_types.Find(id);
            if (needle_types == null)
            {
                return NotFound();
            }

            return Ok(needle_types);
        }

        // PUT: api/needle_types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putneedle_types(int id, needle_types needle_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needle_types.id)
            {
                return BadRequest();
            }

            db.Entry(needle_types).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!needle_typesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/needle_types
        [ResponseType(typeof(needle_types))]
        public IHttpActionResult Postneedle_types(needle_types needle_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.needle_types.Add(needle_types);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (needle_typesExists(needle_types.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = needle_types.id }, needle_types);
        }

        // DELETE: api/needle_types/5
        [ResponseType(typeof(needle_types))]
        public IHttpActionResult Deleteneedle_types(int id)
        {
            needle_types needle_types = db.needle_types.Find(id);
            if (needle_types == null)
            {
                return NotFound();
            }

            db.needle_types.Remove(needle_types);
            db.SaveChanges();

            return Ok(needle_types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool needle_typesExists(int id)
        {
            return db.needle_types.Count(e => e.id == id) > 0;
        }
    }
}