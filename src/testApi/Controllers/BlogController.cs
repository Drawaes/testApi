using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApi.Models;

namespace testApi.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {

        private BloggingContext _context;
        ILogger<BlogsController> _logger;

        public BlogsController(BloggingContext context, ILogger<BlogsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Blog> Index()
        {
            return _context.Blog.ToList();
        }

        [HttpGet("{id}", Name = "GetBlog")]
        public IActionResult GetById(int id)
        {
            var result = _context.Blog.SingleOrDefault(blog => blog.BlogId == id);
            if (result == null)
            {
                return NotFound();
            }

            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Blog blog)
        {
            if (ModelState.IsValid)
            {
                _logger.LogDebug(@"The model is valid");

                try
                {
                    _context.Blog.Add(blog);
                    _context.SaveChanges();
                } catch (Exception e)
                {
                    _logger.LogDebug(e.ToString());
                    return BadRequest();
                }
                
            } else
            {
                _logger.LogDebug(@"The model is not valid");
                return BadRequest();
            }

            return CreatedAtRoute("GetBlog", new { id = blog.BlogId }, blog);
        }

    }
}
