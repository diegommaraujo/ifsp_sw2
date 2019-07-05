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
    public class TelefonesController : ApiController
    {
        private LojaContext db = new LojaContext();

        // GET: api/Telefones
        public IQueryable<Telefone> GetTelefones()
        {
            return db.Telefones;
        }

        // GET: api/Telefones/5
        [ResponseType(typeof(Telefone))]
        public IHttpActionResult GetTelefone(int id)
        {
            Telefone telefone = db.Telefones.Find(id);
            if (telefone == null)
            {
                return NotFound();
            }

            return Ok(telefone);
        }

        // PUT: api/Telefones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelefone(int id, Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefone.ID)
            {
                return BadRequest();
            }

            db.Entry(telefone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
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

        // POST: api/Telefones
        [ResponseType(typeof(Telefone))]
        public IHttpActionResult PostTelefone(Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telefones.Add(telefone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telefone.ID }, telefone);
        }

        // DELETE: api/Telefones/5
        [ResponseType(typeof(Telefone))]
        public IHttpActionResult DeleteTelefone(int id)
        {
            Telefone telefone = db.Telefones.Find(id);
            if (telefone == null)
            {
                return NotFound();
            }

            db.Telefones.Remove(telefone);
            db.SaveChanges();

            return Ok(telefone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefoneExists(int id)
        {
            return db.Telefones.Count(e => e.ID == id) > 0;
        }
    }
}