﻿using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class PostRepository : IPostRepository

    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public bool Add(Post post)
        {
            _context.Add(post);
            return Save();
        }

        public bool Delete(Post post)
        {
            _context.Remove(post);
            return Save();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
