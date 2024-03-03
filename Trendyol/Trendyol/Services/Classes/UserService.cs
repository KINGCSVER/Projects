using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Context;
using Trendyol.Models;

namespace Trendyol.Services.Classes;

public class UserService
{
    private readonly TrendyolDbContext _context;

    public UserService(TrendyolDbContext context)
    {
        _context = context;
    }

    public User LoginGet(string username)
    {
        return _context.User.FirstOrDefault(u => u.Username == username);
    }

    public bool UserLogin(string username, string password)
    {
        User user = _context.User.FirstOrDefault(u => u.Username == username);

        if (user != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        return false;
    }

    public User RegisterUser(string name, string email, string password)
    {
        User user = new User
        {
            Username = name,
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password)         
        };

        return user;
    }
}