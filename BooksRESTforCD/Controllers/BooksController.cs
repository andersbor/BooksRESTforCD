﻿using BooksRESTforCD.Models;
using BooksRESTforCD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BooksRESTforCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksRepository repo;
        public BooksController(BooksRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get(string? sort_by = null, int? price_below = null)
        {
            return repo.GetAll(sort_by, price_below);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            Book? book = repo.GetById(id);
            if (book == null)
            {
                return NotFound("No such id: " + id);
            }
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            try
            {
                Book newBook = repo.Add(book);
                //return Ok(newBook);
                return Created(
                    Url.ActionContext.HttpContext.Request.Path + "/" + newBook.Id,
                    newBook);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            Book? book = repo.Delete(id);
            if (book == null)
            {
                return NotFound("No such id: " + id);
            }
            return Ok(book);
        }
    }
}
