using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class People
    {
        [Key]

        public int PeopleId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
