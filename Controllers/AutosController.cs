﻿using System;
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
    public class AutosController : Controller
    {
        private readonly AutoRepository db;
        public AutosController(AutoRepository autoRepo)
        {
            db = autoRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return db.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Auto Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public Auto Post([FromBody]Auto auto)
        {
            if (ModelState.IsValid)
            {
                return db.Add(auto);
            }
            return null;
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public Auto Put(int id, [FromBody]Auto auto)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, auto);
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