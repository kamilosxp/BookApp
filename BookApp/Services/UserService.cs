using System;
using System.Collections.Generic;
using System.Linq;
using BookApp.Models;

namespace BookApp.Services
{
    public class UserService : IUserService
    {
        private readonly BookAppContext _context;

        public UserService(BookAppContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            return true;
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool IsPasswordCorrect(string email, string enteredPass)
        {
            var users = _context.Users.ToList();
            var user = users.FirstOrDefault(a => a.Email == email);
            var correctPassword = user != null && user.Password == enteredPass;

            return correctPassword;
        }

        public bool IsUserExist(string email)
        {
            var users = _context.Users;
            //var exist = users.Exists(a => a.Email == email);

            return true;
        }

        public bool IsUserExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
