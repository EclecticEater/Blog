using Blog.Models;

namespace Blog.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();

        Task<Post> GetByIdAsync(int id);

        bool Add (Post post);

        bool Update (Post post);

        bool Delete (Post post);

        bool Save ();

    }
}
