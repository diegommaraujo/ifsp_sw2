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
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ConsultorsController : ApiController
    {
        private LojaContext db = new LojaContext();

        // GET: api/Consultors
        public IQueryable<Consultor> GetConsultors()
        {
            return db.Consultors;
        }

        // GET: api/Consultors/5
        [ResponseType(typeof(Consultor))]
        public IHttpActionResult GetConsultor(int id)
        {
            Consultor consultor = db.Consultors.Find(id);
            if (consultor == null)
            {
                return NotFound();
            }

            return Ok(consultor);
        }

        // PUT: api/Consultors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsultor(int id, Consultor consultor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultor.ID)
            {
                return BadRequest();
            }

            db.Entry(consultor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultorExists(id))
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

        // POST: api/Consultors
        [ResponseType(typeof(Consultor))]
        public IHttpActionResult PostConsultor(Consultor consultor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultors.Add(consultor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consultor.ID }, consultor);
        }

        // DELETE: api/Consultors/5
        [ResponseType(typeof(Consultor))]
        public IHttpActionResult DeleteConsultor(int id)
        {
            Consultor consultor = db.Consultors.Find(id);
            if (consultor == null)
            {
                return NotFound();
            }

            db.Consultors.Remove(consultor);
            db.SaveChanges();

            return Ok(consultor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultorExists(int id)
        {
            return db.Consultors.Count(e => e.ID == id) > 0;
        }
    }
}