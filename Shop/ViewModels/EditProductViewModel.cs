using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.Products.Queries.GetProducts;
using Shop.Domain.Models;

namespace Shop.ViewModels
{
    public class EditProductViewModel//находиться в контроллере Product Админа метод Edit
    {
        public CreateProductViewModel Data { get; set; }
        public Product Product { get; set; }
    }
}
