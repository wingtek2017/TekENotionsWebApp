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
    public class CircularNeedleSizesController : ApiController
    {
        private TekENotionsEntities db = new TekENotionsEntities();

        // GET: api/circularNeedleSizes
        public IQueryable<string> GetcircularNeedleSizes()
        {
            return db.CircularNeedleSizes.Select(m => m.description).Distinct();
           
        }

        // GET: api/circularNeedleSizes/5
        [ResponseType(typeof(CircularNeedleSize))]
        public IHttpActionResult GetcircularNeedleSize(int id)
        {
            CircularNeedleSize circularNeedleSize = db.CircularNeedleSizes.Find(id);
            if (circularNeedleSize == null)
            {
                return NotFound();
            }

            return Ok(circularNeedleSize);
        }

        // PUT: api/circularNeedleSizes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcircularNeedleSize(int id, CircularNeedleSize circularNeedleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != circularNeedleSize.id)
            {
                return BadRequest();
            }

            db.Entry(circularNeedleSize).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircularNeedleSizeExists(id))
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

        // POST: api/circularNeedleSizes
        [ResponseType(typeof(CircularNeedleSize))]
        public IHttpActionResult PostcircularNeedleSize(CircularNeedleSize circularNeedleSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CircularNeedleSizes.Add(circularNeedleSize);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = circularNeedleSize.id }, circularNeedleSize);
        }

        // DELETE: api/circularNeedleSizes/5
        [ResponseType(typeof(CircularNeedleSize))]
        public IHttpActionResult DeletecircularNeedleSize(int id)
        {
            CircularNeedleSize circularNeedleSize = db.CircularNeedleSizes.Find(id);
            if (circularNeedleSize == null)
            {
                return NotFound();
            }

            db.CircularNeedleSizes.Remove(circularNeedleSize);
            db.SaveChanges();

            return Ok(circularNeedleSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CircularNeedleSizeExists(int id)
        {
            return db.CircularNeedleSizes.Count(e => e.id == id) > 0;
        }
    }
}