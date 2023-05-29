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
        public EventsController(EventsDbContext context)
        {
            _context = context;
        }

        // GET /api/events
        [HttpGet]
        public IActionResult GetAll()
        {
            var events = _context.Events;

            return Ok(_context.Events);
        }

        // GET /api/events/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var events = _context.Events.SingleOrDefault(events => events.Id == id);

            if (events == null)
                return NotFound();

            return Ok(events);
        }

        /// <summary>
        /// Cadastro de Evento
        /// </summary>
        /// <remarks>
        /// {
        ///     "title": "Titulo da aplicação",
        ///     "description": "Descrição da aplicação",
        ///     "organization": "teste",
        ///     "initialDate": "2023-05-29T20:20:00.000Z",
        ///     "finalDate": "2023-05-29T20:20:00.000Z",
        /// }
        /// </remarks>
        /// <param name="events">Dados do Evento</param>
        /// <returns>Evento recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Event events)
        {
            _context.Events.Add(events);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = events.Id }, events);
        }

        // PUT /api/events/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Event events)
        {
            var existsEvent = _context.Events.SingleOrDefault(events => events.Id == id);

            if (existsEvent == null)
                return NotFound();

            existsEvent.Update(events.Title, events.Description, events.InitialDate, events.FinalDate);

            _context.Events.Update(existsEvent);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE /api/events/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var events = _context.Events.SingleOrDefault(events => events.Id == id);

            if (events == null)
                return NotFound();

            _context.Events.Remove(events);
            _context.SaveChanges();

            return NoContent();
        }
    }
}