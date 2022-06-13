using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using mgrapi.Dtos.User;
using mgrapi.Interfaces;
using mgrapi.Models;

namespace mgrapi.Services
{
    public class UsersService : IUsersService
    {
        private readonly RepositoryContext _context;

        public UsersService(IMapper mapper, RepositoryContext context)
        {
            _mapper = mapper;
            _context = context;
            // SeedUsers();
        }

        private void SeedUsers() {  
            List<User> users = new List<User>();

            for(int i = 0; i < 100; i++) {
                var newUser = new User()
                {
                    // UserId = i,
                    FirstName = "Imie" + (i + 1).ToString(),
                    LastName = "Nazwisko" + (i + 1).ToString(),
                    PhoneNumber = "111 111 111",
                    Email = "test@test.com"
                };

                users.Add(newUser);
            }
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
      
        private readonly IMapper _mapper;

        public int Create(CreateUserDto user)
        {
            var id = _context.Users.ToList().Count > 0
              ? _context.Users.Max(u => u.UserId) + 1
              : 0;

            var userToAdd = _mapper.Map<CreateUserDto, User>(user);

            _context.Users.Add(userToAdd);
            _context.SaveChanges();

            return id;        
        }

        public bool Delete(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (userToDelete == null)
                return false;

            var deletedUser = _context.Users.Remove(userToDelete);

            bool isDeleted = false;
            if(deletedUser != null)
            {
                isDeleted = true;
            }

            _context.SaveChanges();

            return isDeleted;
        }

        public GetUserByIdDto Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            var dto = _mapper.Map<GetUserByIdDto>(user);

            return dto;        }

        public GetAllUsersDto GetAll()
        {
            var allUsers = _context.Users.ToList();

            var dto = new GetAllUsersDto
            {
                Users = _mapper.Map<List<UserForGetAllUsersDto>>(allUsers)
            };

            return dto;      

            // throw new NotImplementedException();    

        }

        public bool Update(int id, UpdateUserDto user)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (userToUpdate == null)
                return false;

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.Email = user.Email;

            _context.Users.Update(userToUpdate);
            _context.SaveChanges();

            return true;
        }
    }
}