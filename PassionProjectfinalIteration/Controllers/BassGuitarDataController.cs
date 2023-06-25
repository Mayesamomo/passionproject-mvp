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
using PassionProjectfinalIteration.Models;

namespace PassionProjectfinalIteration.Controllers
{
    public class BassGuitarDataController : ApiController
    {
        
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BassGuitarData/ListGuitars
        [HttpGet]
        public IEnumerable<BassGuitarDTO> ListGuitars()
        {
            List<BassGuitar> bassGuitars= db.BassGuitars.ToList();
            List<BassGuitarDTO> bassGuitarDTOs = new List<BassGuitarDTO>();
            bassGuitars.ForEach(a => bassGuitarDTOs.Add(new BassGuitarDTO()
            {
                ID = a.ID,
                Color = a.Color,
                NumberOfStrings = a.NumberOfStrings,
                Model = a.Model,    
                Manufacturer = a.Manufacturer,
                CategoryID = a.CategoryID,
                CategoryName = a.Category.CategoryName,
                OwnerID = a.OwnerID,
                OwnerName = a.Owner.Name,
                BassGuitarHasPic = a.BassGuitarHasPic,
                PicExtension = a.PicExtension

            }));
            return bassGuitarDTOs;
        }

        // GET: api/BassGuitarData/GetBassGuitar/3
        [HttpGet]
        [ResponseType(typeof(BassGuitar))]
        public IHttpActionResult GetBassGuitar(int id)
        {
            
        BassGuitar bassGuitar = db.BassGuitars.Find(id);

            if (bassGuitar == null)
            {
                return NotFound();
            }

            BassGuitarDTO bassGuitarDTO = new BassGuitarDTO()
            {
                ID = bassGuitar.ID,
                Color = bassGuitar.Color,
                NumberOfStrings = bassGuitar.NumberOfStrings,
                Model = bassGuitar.Model,
                Manufacturer = bassGuitar.Manufacturer,
                CategoryID = bassGuitar.CategoryID,
                CategoryName = bassGuitar.Category.CategoryName,
                OwnerID = bassGuitar.OwnerID,
                OwnerName = bassGuitar.Owner.Name,
                BassGuitarHasPic = bassGuitar.BassGuitarHasPic,
                PicExtension = bassGuitar.PicExtension
            };

            return Ok(bassGuitarDTO);
        }

        // PUT: api/BassGuitarData/UpdateBassGuitar/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateBassGuitar(int id, BassGuitar bassGuitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bassGuitar.ID)
            {
                return BadRequest();
            }

            db.Entry(bassGuitar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BassGuitarExists(id))
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

        // POST: api/BassGuitarData/AddBassGuitar
        [ResponseType(typeof(BassGuitar))]
        [HttpPost]
        public IHttpActionResult AddBassGuitar(BassGuitar bassGuitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BassGuitars.Add(bassGuitar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bassGuitar.ID }, bassGuitar);
        }

        // DELETE: api/BassGuitarData/DeleteBassGuitar/5
        [ResponseType(typeof(BassGuitar))]
        [HttpPost]
        public IHttpActionResult DeleteBassGuitar(int id)
        {
            BassGuitar bassGuitar = db.BassGuitars.Find(id);
            if (bassGuitar == null)
            {
                return NotFound();
            }

            db.BassGuitars.Remove(bassGuitar);
            db.SaveChanges();

            return Ok(bassGuitar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BassGuitarExists(int id)
        {
            return db.BassGuitars.Count(e => e.ID == id) > 0;
        }

      
    }
}