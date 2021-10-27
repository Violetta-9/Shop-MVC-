using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.Categories.Queries;
using Shop.Application.Products.Queries.GetProducts;
using Shop.Application.Vendors.Queries;
using Shop.Domain.Models;

namespace Shop.ViewModels
{
    public class CommonViewModel
    {
        public CategoriesViewModel Category { get; set; }
        public VendorsViewModel Vendor { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
