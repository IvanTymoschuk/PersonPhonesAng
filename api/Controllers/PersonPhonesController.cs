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
   
    [RoutePrefix("Phones")]
    public class PersonPhonesController : ApiController
    {
        private Context db = new Context();

        // GET: api/PersonPhones
        [HttpGet]
        [Route("PersonPhones")]
        public IQueryable<PersonPhone> GetMyEntities()
        {
            return db.Phones;
        }

        // GET: api/PersonPhones/5
        [HttpGet]
        [Route("GetPhoneById/{id}")]
        [ResponseType(typeof(PersonPhone))]
        public IHttpActionResult GetPersonPhone(int id)
        {
            PersonPhone personPhone = db.Phones.Find(id);
            if (personPhone == null)
            {
                return NotFound();
            }

            return Ok(personPhone);
        }

        // PUT: api/PersonPhones/5

        [ResponseType(typeof(void))]
        [Route("UpdatePhone/{id}")]
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
        [HttpPost]
        [Route("CreatePhone")]
        [ResponseType(typeof(PersonPhone))]
        public IHttpActionResult PostPersonPhone(PersonPhone personPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phones.Add(personPhone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personPhone.Id }, personPhone);
        }

        // DELETE: api/PersonPhones/5
        [ResponseType(typeof(PersonPhone))]
        [HttpDelete]
        [Route("DeletePhone/{id}")]
        public IHttpActionResult DeletePersonPhone(int id)
        {
            PersonPhone personPhone = db.Phones.Find(id);
            if (personPhone == null)
            {
                return NotFound();
            }

            db.Phones.Remove(personPhone);
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
            return db.Phones.Count(e => e.Id == id) > 0;
        }
    }
}