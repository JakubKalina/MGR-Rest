using System;
using System.Collections.Generic;

namespace mgrapi.Dtos.Post
{
    public class GetAllPostsDto
    {
        public ICollection<PostForGetAllPostsDto> Posts { get; set; }
    }

    public class PostForGetAllPostsDto
    {
        public int PostId { get; set; }

        public DateTime CreationDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
        // public User User { get; set; }
        public int CategoryId { get; set; }
        // public Category Category { get; set; }
    }
}
