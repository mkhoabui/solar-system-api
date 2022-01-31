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
    public class ClientController : ControllerBase
    {
        private DataContext dc;

        public ClientController(DataContext context)
        {
            this.dc = context;
        }

        [HttpPost("final")]
        public async Task<ActionResult> register([FromBody] Client c)
        {
            //prepare to register
            dc.client.Add(c);
            await dc.SaveChangesAsync();
            return Created("Client Object", c);
        }

        [HttpGet("final")]
        public async Task<ActionResult> list()
        {
            var data = await dc.client.ToListAsync();
            //this return Ok means this function will only list/read;
            return Ok(data);
        }

        [HttpGet("final/{id}")]
        public Client search(int id)
        {
            Client c = dc.client.Find(id);
            return c;
        }

        [HttpPut("final")]
        public async Task<ActionResult> edit([FromBody] Client c)
        {
            dc.client.Update(c);
            await dc.SaveChangesAsync();
            return Ok(c);
        }

        [HttpDelete("final/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Client c = search(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                dc.client.Remove(c);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }
}