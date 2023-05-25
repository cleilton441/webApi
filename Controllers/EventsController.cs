using DevEvents.API.Entities;
using DevEvents.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevEvents.API.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly EventsDbContext _context;
        public EventsController(EventsDbContext context){
            _context = context;
        }

        // GET /api/events
        [HttpGet]
        public IActionResult GetAll(){
            var events = _context.Events;

            return Ok(_context.Events);
        }
        
        // GET /api/events/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var events = _context.Events.SingleOrDefault(events => events.Id == id);

            if(events == null)
                return NotFound();

            return Ok(events);
        }

        // POST /api/events
        [HttpPost]
        public IActionResult Post(Event events){
            _context.Events.Add(events);

            return CreatedAtAction(nameof(GetById), new{id = events.Id}, events);
        }

        // PUT /api/events/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Event events){
             var existsEvent = _context.Events.SingleOrDefault(events => events.Id == id);

            if(existsEvent == null)
                return NotFound();

            existsEvent.Update(events.Title, events.Description, events.InitialDate, events.FinalDate);  

            return NoContent();
        }

        // DELETE /api/events/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var events = _context.Events.SingleOrDefault(events => events.Id == id);

            if(events == null)
                return NotFound();
            
            _context.Events.Remove(events);

           return NoContent(); 
        }
    }
}