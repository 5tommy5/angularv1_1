using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        business.Domains.Dog domain;
        data.WebBasicsDBContext db;

        public DogController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Dog(configuration);
            this.db = new data.WebBasicsDBContext(configuration);
        }

        [HttpGet]
        public IEnumerable<data.Entities.Dog> Get()
        {
            return db.Dogs.ToList();
        }

        [HttpGet("{id}")]
        public data.Entities.Dog Get(int id)
        {
            data.Entities.Dog dog = db.Dogs.FirstOrDefault(x => x.Id == id);
            return dog;
        }

        [HttpPost]
        public IActionResult Post(data.Entities.Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Dogs.Add(dog);
                db.SaveChanges();
                return Ok(dog);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(data.Entities.Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Update(dog);
                db.SaveChanges();
                return Ok(dog);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            data.Entities.Dog dog = db.Dogs.FirstOrDefault(x => x.Id == id);
            if (dog != null)
            {
                db.Dogs.Remove(dog);
                db.SaveChanges();
            }
            return Ok(dog);
        }
    }
}
