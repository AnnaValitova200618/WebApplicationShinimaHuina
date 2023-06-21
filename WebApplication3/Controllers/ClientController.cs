using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Vorobyov11414Context db;
        public ClientController(Vorobyov11414Context db)
        {
            this.db = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            var хуйня = db.Clients.ToList();
            return хуйня;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var client = db.Clients.FirstOrDefault(s => s.Id == id);
            return client == null ? NotFound("идите на хуй") : Ok(client);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Client newClient)
        {
            try
            {
                db.Clients.Add(newClient);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Client value)
        {
            var old = db.Clients.FirstOrDefault(s => s.Id == id);
            if (old == null)
                return NotFound();
            try
            {
                db.Entry(old).CurrentValues.SetValues(value);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var old = db.Clients.FirstOrDefault(s => s.Id == id);
            if (old == null)
                return NotFound();
            try
            {
                db.Clients.Remove(old);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
