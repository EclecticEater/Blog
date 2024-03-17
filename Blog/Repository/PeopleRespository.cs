using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class PeopleRespository : IPeopleRepository

    {
        private readonly ApplicationDbContext _context;

        public PeopleRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(People people)
        {
            _context.Add(people);
            return Save();
        }

        public bool Delete(People people)
        {
            _context.Remove(people);
            return Save();
        }


        public async Task<People> GetByIdAsync(int id)
        {
            return await _context.People.FirstOrDefaultAsync(i => i.PeopleId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(People people)
        {
            throw new NotImplementedException();
        }
    }
}
