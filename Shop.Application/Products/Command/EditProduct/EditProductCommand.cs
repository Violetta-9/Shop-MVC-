using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Products.Command.EditProduct
{
    public class EditProductCommand:IRequest<Product>
    {
        public int ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }
        public string Image { get; }

        public EditProductCommand(int productId,string name, string description, double price)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
        
        }

    }
}
