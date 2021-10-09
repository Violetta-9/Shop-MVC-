using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.Categories.Queries;
using Shop.Application.Vendors.Queries;
using Shop.DataAccess.Migrations;
using Shop.Domain.Models;

namespace Shop.ViewModels
{
    public class CreateProductViewModel
    {
        public CategoriesViewModel Categories { get; set; }
        public VendorsViewModel Vendors { get; set; }
    }
}
