using mgrapi.Dtos.Post;

namespace mgrapi.Interfaces
{
    public interface IPostsService
    {
        GetAllPostsDto GetAll();
        GetPostByIdDto Get(int id);

        int Create(CreatePostDto user);

        bool Update(int id, UpdatePostDto pizza);

        bool Delete(int id);
    }
}