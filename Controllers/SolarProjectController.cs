//Will Focus to work with assyncronous programming.
using System.Threading.Tasks;

//To have access to our DataContex that gives us access to DB CRUD of our Person Model
using final.Data;

//Responsable by the routes creation
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using final.Models;

namespace final.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class SolarProjectController : ControllerBase
    {
        private DataContext dc;

        public SolarProjectController(DataContext context)
        {
            this.dc = context;
        }

        [HttpPost("final")]
        public async Task<ActionResult> register([FromBody] SolarProject s)
        {
            //prepare to register
            dc.solarProject.Add(s);
            await dc.SaveChangesAsync();
            return Created("Solar Project Object", s);
        }

        [HttpGet("final")]
        public async Task<ActionResult> list()
        {
            var data = await dc.client.ToListAsync();
            //this return Ok means this function will only list/read;
            return Ok(data);
        }

        [HttpGet("final/{id}")]
        public SolarProject search(int id)
        {
            SolarProject s = dc.solarProject.Find(id);
            return s;
        }

        [HttpPut("final")]
        public async Task<ActionResult> edit([FromBody] SolarProject s)
        {
            dc.solarProject.Update(s);
            await dc.SaveChangesAsync();
            return Ok(s);
        }

        [HttpDelete("final/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            SolarProject s = search(id);
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                dc.solarProject.Remove(s);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }
}