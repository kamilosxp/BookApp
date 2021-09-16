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
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool ChangePassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string password, User user)
        {
            var usr = _context.Users.FirstOrDefault(a => a.Email == user.Email);
            usr.Password = password;

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
            var users = _context.Users.ToList();
            var exist = users.Exists(a => a.Email == email);
            return exist == true;
        }

        public bool IsUserExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
