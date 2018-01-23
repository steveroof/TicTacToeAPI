using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Models;
using System.Linq;
using System;
using Newtonsoft.Json;

namespace TicTacToeAPI.Controllers
{
    [Route("api/[controller]")]
    public class TicTacToeController : Controller
    {
        private readonly TicTacToeContext _context;

        public TicTacToeController(TicTacToeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<TicTacToeItem> GetAll()
        {
            return _context.TicTacToeItems.ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Object o)
        {
            if (o == null)
            {
                return BadRequest();
            }

            TicTacToeItem result = new TicTacToeItem();
            result.gameState = o.ToString();

            _context.TicTacToeItems.Add(result);
            _context.SaveChanges();

            return new NoContentResult();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            var TicTacToe = _context.TicTacToeItems;

            foreach (TicTacToeItem item in _context.TicTacToeItems)
            {
                _context.Remove(item);
            }
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}