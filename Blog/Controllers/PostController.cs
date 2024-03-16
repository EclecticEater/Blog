using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class PostController : Controller

    {
        private readonly ApplicationDbContext _context;
        public PostController(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            var posts = _context.Posts.Include(a => a.People).ToList();
            return View(posts);
        }
        public IActionResult Detail(int id)
        {
            Post post = _context.Posts.Include(a => a.People).FirstOrDefault(c => c.Id == id);
            return View(post);
        }
    }
}
