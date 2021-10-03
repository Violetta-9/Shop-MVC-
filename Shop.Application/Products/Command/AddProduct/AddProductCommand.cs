using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.Products.Command.AddProducts
{
   public class AddProductCommand : IRequest<int>
   {  
       public string Name { get; set; }
       public string Description { get; set; }
       public double Price { get; private set; }
       public string Image { get; private set; }

       public AddProductCommand(string name, string description, double price, string image)
       {
           Name = name;
           Description = description;
           Price = price;
           Image = image;
       }
    }
}
