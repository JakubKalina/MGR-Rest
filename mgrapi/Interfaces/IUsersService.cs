using mgrapi.Dtos.User;

namespace mgrapi.Interfaces
{
    public interface IUsersService
    {
        GetAllUsersDto GetAll();
        GetUserByIdDto Get(int id);

        int Create(CreateUserDto user);

        bool Update(int id, UpdateUserDto pizza);

        bool Delete(int id);
    }
}