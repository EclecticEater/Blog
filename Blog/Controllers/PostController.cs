using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class PostController : Controller

    {
        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostController> _logger;
        public PostController(ILogger<PostController> logger, IPostRepository postRepository) 
        { 
            _postRepository = postRepository;
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<Post> posts = await _postRepository.GetAll();
            return View(posts);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Post posts = await _postRepository.GetByIdAsync(id);
            return View(posts);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Post post)
        {
            var NameClaim = User.Claims.First(c => c.Type == "name");
            var displayname = NameClaim.Value;

            if (!ModelState.IsValid)
            {
                return View(post);
            }
            post.CreatedDate = DateTime.Now;
            post.DisplayName = displayname;
            _postRepository.Add(post);
            return RedirectToAction("Index");
        }
    }
}
