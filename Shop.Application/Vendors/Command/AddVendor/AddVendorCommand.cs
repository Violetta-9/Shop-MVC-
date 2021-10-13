using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.Vendors.Command
{
    public class AddVendorCommand:IRequest<int>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public AddVendorCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
