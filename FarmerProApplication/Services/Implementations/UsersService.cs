using AutoMapper;
using FarmerProApplication.Cryptography;
using FarmerProApplication.Dtos.User;
using FarmerProApplication.Model;
using FarmerProApplication.Models.DatabaseModels;
using FarmerProApplication.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmerProApplication.Services.Implementations
{
    class UsersService : IUsersService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;

        public UsersService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(CreateUserDto createUser)
        {
            var user = _mapper.Map<User>(createUser);
       
            user.PasswordHash = PasswordHasher.HashPassword(createUser.Password);
         
            user.CreatedAt = DateTime.UtcNow;

            _context.Add(user);

            _context.SaveChanges();
        }

        public UserDto Get(int userId)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == userId);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public List<UserDto> GetAll()
        {
            var users = _context.Users.ToList();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return userDtos;
        }

        public void Remove(int userId)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(int userId, CreateUserDto updateUser)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == userId);
            user = _mapper.Map(updateUser, user);
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
