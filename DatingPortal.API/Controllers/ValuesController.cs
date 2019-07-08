using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingPortal.API.Data;
using DatingPortal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext context;

        public ValuesController(DataContext context)
        {
            this.context = context;
        }

        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddValue([FromBody] Value value)
        {
            context.Values.Add(value);
            await context.SaveChangesAsync();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditValue(int id, [FromBody] Value value)
        {
            var data = await context.Values.FindAsync(id);
            data.Name = value.Name;
            context.Values.Update(data);
            await context.SaveChangesAsync();

            return Ok(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            var data = await context.Values.FindAsync(id);

            if (data == null)
                return NoContent();

            context.Values.Remove(data);
            await context.SaveChangesAsync();

            return Ok(data);
        }


    }
}
