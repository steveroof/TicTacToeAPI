using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Models;
using System.Linq;

namespace TicTacToeAPI.Controllers
{
    [Route("api/TicTacToe")]
    public class TicTacToeController : Controller
    {
        private readonly TicTacToeContext _context;

        public TicTacToeController(TicTacToeContext context)
        {
            _context = context;

            if (_context.TicTacToeItems.Count() == 0)
            {
                _context.TicTacToeItems.Add(new TicTacToeItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<TicTacToeItem> GetAll()
        {
            return _context.TicTacToeItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTicTacToe")]
        public IActionResult GetById(long id)
        {
            var item = _context.TicTacToeItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] TicTacToeItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TicTacToeItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTicTacToe", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TicTacToeItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var TicTacToe = _context.TicTacToeItems.FirstOrDefault(t => t.Id == id);
            if (TicTacToe == null)
            {
                return NotFound();
            }

            TicTacToe.IsComplete = item.IsComplete;
            TicTacToe.Name = item.Name;

            _context.TicTacToeItems.Update(TicTacToe);
            _context.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var TicTacToe = _context.TicTacToeItems.FirstOrDefault(t => t.Id == id);
            if (TicTacToe == null)
            {
                return NotFound();
            }

            _context.TicTacToeItems.Remove(TicTacToe);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}