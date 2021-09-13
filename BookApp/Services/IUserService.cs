using System;
using System.Collections.Generic;
using BookApp.Models;

namespace BookApp.Services
{
    public interface IUserService
    {
        bool AddUser(User user);
        bool DeleteUser (User user);
        bool IsUserExist(string email);
        bool IsUserExist(int id);
        bool IsPasswordCorrect(string email, string enteredPass);
        List<User> GetUsers ();
    }
}
