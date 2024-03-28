using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Email
    {
        [Key]

        public int Id { get; set; }

        public string userName { get; set; }

        public string emailAddress { get; set; }

        public string message { get; set; }
    }
}
