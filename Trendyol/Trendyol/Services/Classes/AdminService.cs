﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Context;
using Trendyol.Models;

namespace Trendyol.Services.Classes;

public class AdminService
{
    private readonly TrendyolDbContext _context;

    public AdminService(TrendyolDbContext context)
    {
        _context = context;
    }

    public Admin AdminRegister(string login, string password)
    {
        Admin admin = new Admin
        {
            Name = login,
            Password = BCrypt.Net.BCrypt.HashPassword(password)
        };
        return admin;
    }

    public bool AdminLogin(string login, string password)
    {
        Admin admin = _context.Admin.FirstOrDefault(a => a.Name == login);
        if (admin != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, admin.Password);
        }
        return false;
    }
}