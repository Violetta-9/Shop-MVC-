﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Domain.Models;

namespace Shop.HostedServices
{
    public class CreateRolesHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        

        public CreateRolesHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
          
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
             const string roleName = "Admin";

             using (var scope = _serviceProvider.CreateScope())
             {

                 var manager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                 var role = new IdentityRole(roleName);
                 var resultOfManager = manager.CreateAsync(role).Result;

                 var user = scope.ServiceProvider.GetRequiredService<UserManager<ShopUser>>();
                 var resulOfUsers = user.FindByEmailAsync("v_z@gmail.com").Result;

                 if (resultOfManager.Succeeded)
                 {
                     user.AddToRoleAsync(resulOfUsers, roleName);

                 }
            }

           return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
