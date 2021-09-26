﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Domain.Models;

namespace Shop.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ShopUser, IdentityRole, string>
    {
        public  DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}