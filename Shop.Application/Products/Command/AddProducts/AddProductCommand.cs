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
    }
}
