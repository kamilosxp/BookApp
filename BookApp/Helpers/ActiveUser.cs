using System;
using BookApp.Models;
using BookApp.Services;

namespace BookApp.Helpers
{
    public static class ActiveUser
    {
        private static User _user;

        public static void SetUser(User user) => _user = user;

        public static User GetUser() => _user;

    }
}
