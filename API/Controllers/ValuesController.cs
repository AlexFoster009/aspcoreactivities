using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Define a private variable to use inside this class.
        private readonly DataContext _context;
        // Define constructor for dependency injection.
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task <ActionResult<IEnumerable<Value>>> Get()
        {
            /*
             * Instead of returning string we will return
             * a list using our database data.
             */
            var values = await _context.Values.ToListAsync();
            // Returns a 200 http response.
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task< ActionResult<Value>> Get(int id)
        {
            // Look for value vby the id passed. if not, return null.
            var value = await _context.Values.FindAsync(id);
            return Ok(value);

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
