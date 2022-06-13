using System;
using System.ComponentModel.DataAnnotations;

namespace mgrapi.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public DateTime CreationDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}