namespace mgrapi.Dtos.User
{
    public class GetUserByIdDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}