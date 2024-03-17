using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
        [Key][BindNever]

        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Body { get; set; }

        [ForeignKey("People")]

        public int PeopleId { get; set; }

        public People? People { get; set; }


    }
}
