using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using api;

namespace api.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class PersonPhonesController : ApiController
    {
        private Context db = new Context();

        // GET: api/PersonPhones
        public IQueryable<PersonPhone> GetMyEntities()
        {
            return db.MyEntities;
        }

        // GET: api/PersonPhones/5
        [ResponseType(typeof(PersonPhone))]
        public IHttpActionResult GetPersonPhone(int id)
        {
            PersonPhone personPhone = db.MyEntities.Find(id);
            if (personPhone == null)
            {
                return NotFound();
            }

            return Ok(personPhone);
        }

        // PUT: api/PersonPhones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonPhone(int id, PersonPhone personPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personPhone.Id)
            {
                return BadRequest();
            }

            db.Entry(personPhone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonPhoneExists(id))
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

        // POST: api/PersonPhones
        [ResponseType(typeof(PersonPhone))]
        public IHttpActionResult PostPersonPhone(PersonPhone personPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyEntities.Add(personPhone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personPhone.Id }, personPhone);
        }

        // DELETE: api/PersonPhones/5
        [ResponseType(typeof(PersonPhone))]
        public IHttpActionResult DeletePersonPhone(int id)
        {
            PersonPhone personPhone = db.MyEntities.Find(id);
            if (personPhone == null)
            {
                return NotFound();
            }

            db.MyEntities.Remove(personPhone);
            db.SaveChanges();

            return Ok(personPhone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonPhoneExists(int id)
        {
            return db.MyEntities.Count(e => e.Id == id) > 0;
        }
    }
}