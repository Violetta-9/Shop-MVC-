using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Vendors.Command.EditVendor
{
   public class EditVendorCommand:IRequest<Vendor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EditVendorCommand(int id,string name,string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
