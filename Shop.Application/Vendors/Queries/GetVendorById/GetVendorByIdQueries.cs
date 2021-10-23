using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Vendors.Queries.GetCategoryById
{
     public class GetVendorByIdQueries:IRequest<Vendor>

    {
        public int Id { get; set; }
       

        public GetVendorByIdQueries(int id)
        {
            Id = id;
           
        }
    }
}
