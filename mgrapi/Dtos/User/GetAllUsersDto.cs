using System.Collections.Generic;

namespace mgrapi.Dtos.User
{
    public class GetAllUsersDto
    {
        public ICollection<UserForGetAllUsersDto> Users { get; set; }
    }

    public class UserForGetAllUsersDto 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}