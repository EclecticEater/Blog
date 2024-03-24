using Blog.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class PostViewModel
    {
   
        public string Title { get; set; }

        public string Summary { get; set; }

        public string Body { get; set; }

        [ForeignKey("People")]

        public int PeopleId { get; set; }

        public People? People { get; set; }

    }
}
