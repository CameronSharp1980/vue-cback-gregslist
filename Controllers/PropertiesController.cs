using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_cback_gregslist.Models;
using vue_cback_gregslist.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace vue_cback_gregslist.Controllers
{
    [Route("api/[controller]")]
    public class PropertiesController : Controller
    {
        private readonly PropertyRepository db;
        public PropertiesController(PropertyRepository propertyRepo)
        {
            db = propertyRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return db.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Property Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public Property Post([FromBody]Property property)
        {
            System.Console.WriteLine("Property: " + property);
            return db.Add(property);
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public Property Put(int id, [FromBody]Property property)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, property);
            }
            return null;
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}