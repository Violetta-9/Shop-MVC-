using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.Vendors.Command.DeleteVendor
{
    public class DeleteVendorCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteVendorCommand(int id)
        {
            Id = id;
        }
    }
}
