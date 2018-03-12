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
    public class Needle_sizesController : ApiController
    {
        private TekENotionsEntities db = new TekENotionsEntities();

        // GET: api/needle_sizes
        public IQueryable<needle_sizes> Getneedle_sizes()
        {
            return db.needle_sizes;
        }

       

       
        // PUT: api/needle_sizes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putneedle_sizes(int id, needle_sizes needle_sizes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needle_sizes.id)
            {
                return BadRequest();
            }

            db.Entry(needle_sizes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Needle_sizesExists(id))
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

        // POST: api/needle_sizes
        [ResponseType(typeof(needle_sizes))]
        public IHttpActionResult Postneedle_sizes(needle_sizes needle_sizes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.needle_sizes.Add(needle_sizes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Needle_sizesExists(needle_sizes.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = needle_sizes.id }, needle_sizes);
        }

        // DELETE: api/needle_sizes/5
        [ResponseType(typeof(needle_sizes))]
        public IHttpActionResult Deleteneedle_sizes(int id)
        {
            needle_sizes needle_sizes = db.needle_sizes.Find(id);
            if (needle_sizes == null)
            {
                return NotFound();
            }

            db.needle_sizes.Remove(needle_sizes);
            db.SaveChanges();

            return Ok(needle_sizes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Needle_sizesExists(int id)
        {
            return db.needle_sizes.Count(e => e.id == id) > 0;
        }
    }
}