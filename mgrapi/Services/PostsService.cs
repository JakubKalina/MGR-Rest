using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using mgrapi.Dtos.Post;
using mgrapi.Interfaces;
using mgrapi.Models;

namespace mgrapi.Services
{
    public class PostsService : IPostsService
    {
        private readonly RepositoryContext _context;
        public PostsService(IMapper mapper, RepositoryContext context)
        {
            _mapper = mapper;
            _context = context;
            // SeedPosts();
        }

        private void SeedPosts() {  
            List<Post> posts = new List<Post>();

            for(int i = 0; i < 10; i++) {
                var newPost = new Post()
                {
                    // PostId = i,
                    CreationDate = DateTime.UtcNow,
                    Title = "Tytuł " + (i + 1).ToString(),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    UserId = 23,
                    CategoryId = 23
                };
                posts.Add(newPost);
            }

            _context.Posts.AddRange(posts);
            _context.SaveChanges();
        }




        private readonly IMapper _mapper;

        public int Create(CreatePostDto post)
        {
            var id = _context.Posts.ToList().Count > 0
              ? _context.Posts.Max(p => p.PostId) + 1
              : 0;

            var postToAdd = _mapper.Map<Post>(post);

            _context.Posts.Add(postToAdd);
            _context.SaveChanges();

            return id;        
        }

        public bool Delete(int id)
        {
            var postToDelete = _context.Posts.FirstOrDefault(p => p.PostId == id);

            if (postToDelete == null)
                return false;

            var deletedPost  = _context.Posts.Remove(postToDelete);

            bool isDeleted = false;
            if(deletedPost != null)
            {
                isDeleted = true;
            }
            
            _context.SaveChanges();

            return isDeleted;
        }

        public GetPostByIdDto Get(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);

            var dto = _mapper.Map<GetPostByIdDto>(post);

            return dto;        }

        public GetAllPostsDto GetAll()
        {
            var allPosts = _context.Posts.ToList();

            var dto = new GetAllPostsDto
            {
                Posts = _mapper.Map<List<PostForGetAllPostsDto>>(allPosts)
            };

            return dto;      

            // throw new NotImplementedException();    
        }

        public bool Update(int id, UpdatePostDto post)
        {
            var postToUpdate = _context.Posts.FirstOrDefault(p => p.PostId == id);

            if (postToUpdate == null)
                return false;

            postToUpdate.CreationDate = post.CreationDate;
            postToUpdate.Title = post.Title;
            postToUpdate.Description = post.Description;

            _context.Posts.Update(postToUpdate);
            _context.SaveChanges();

            return true;
        }
    }
}