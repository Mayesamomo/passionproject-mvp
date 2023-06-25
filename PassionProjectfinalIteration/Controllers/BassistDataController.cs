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
using System.Web.Mvc;
using PassionProjectfinalIteration.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace PassionProjectfinalIteration.Controllers
{
    public class BassistDataController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BassistData/ListBassist
        [HttpGet]
        public IQueryable<Bassist> ListBassist()
        {
            return db.Bassists;
        }

        // GET: api/BassistData/FindBassit/5
        [HttpGet]
        [ResponseType(typeof(Bassist))]
        public IHttpActionResult FindBassit(int id)
        {
            Bassist bassist = db.Bassists.Find(id);
            if (bassist == null)
            {
                return NotFound();
            }

            return Ok(bassist);
        }

        // PUT: api/BassistData/UpdateBassist/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateBassist(int id, Bassist bassist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bassist.ID)
            {
                return BadRequest();
            }

            db.Entry(bassist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BassistExists(id))
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

        // POST: api/BassistData/AddBassist
        [ResponseType(typeof(Bassist))]
        [HttpPost]
        public IHttpActionResult AddBassist(Bassist bassist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bassists.Add(bassist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bassist.ID }, bassist);
        }

        // DELETE: api/BassistData/DeleteBassist/5
        [ResponseType(typeof(Bassist))]
        [HttpPost]
        public IHttpActionResult DeleteBassist(int id)
        {
            Bassist bassist = db.Bassists.Find(id);
            if (bassist == null)
            {
                return NotFound();
            }

            db.Bassists.Remove(bassist);
            db.SaveChanges();

            return Ok(bassist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BassistExists(int id)
        {
            return db.Bassists.Count(e => e.ID == id) > 0;
        }
    }
}