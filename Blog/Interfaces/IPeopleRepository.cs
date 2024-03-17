using Blog.Models;

namespace Blog.Interfaces
{
    public interface IPeopleRepository
    {

        Task<People> GetByIdAsync(int id);

        bool Add(People people);

        bool Update(People people);

        bool Delete(People people);

        bool Save();
    }
}
