
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Domain.Models
{
    public class ShopUser: IdentityUser
    {
        public string FirstName { get; private set; }
        public string LastName { get;private set; }
        public string Addrese { get; private set; }
        public DateTime RegisterDate { get; }

        private ShopUser()
        {
            RegisterDate=DateTime.UtcNow;
        }

        public ShopUser(string login, string firstname, string lastname, string addres, string phone,
            string email) : this()
        {
            SetUserName(login);
            SetFirstName(firstname);
            SetLastName(lastname);
            SetUserAddres(addres);
            SetUserPhone(phone);
            SetUserEmail(email);
            
        }

        private void SetUserName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is empty", nameof(name));
            }

            UserName = name;
        }
        private void SetFirstName(string firstname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentException("Name is empty", nameof(firstname));
            }

            FirstName = firstname;
        }
        private void SetLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentException("Name is empty", nameof(lastname));
            }

            LastName = lastname;
        }
        private void SetUserEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Name is empty", nameof(email));
            }

            Email = email;
        }
        
        private void SetUserPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Name is empty", nameof(phone));
            }

            PhoneNumber = phone;
        }
        private void SetUserAddres(string addres)
        {
            if (string.IsNullOrWhiteSpace(addres))
            {
                throw new ArgumentException("Name is empty", nameof(addres));
            }

            Addrese = addres;
        }

    }
}
