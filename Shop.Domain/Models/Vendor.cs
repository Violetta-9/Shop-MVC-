using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
   public  class Vendor 
   {   public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Vendor()
        {

        }
        public Vendor(string name,string description)
        {
            SetName(name);
            SetDescription(description);

        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name can not be empty", nameof(name));
            }

            Name = name;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("name can not be empty", nameof(description));
            }

            Description = description;
        }
    }
}
