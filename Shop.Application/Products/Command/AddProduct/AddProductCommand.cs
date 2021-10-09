using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace Shop.Application.Products.Command.AddProducts
{
   public class AddProductCommand : IRequest<int>
   {  
       public string Name { get; set; }
       public string Description { get; set; }
       public double Price { get; private set; }
       public string Image { get; private set; }
       public int CategoryId { get; private set; }
       public int VendorId { get; private set; }
       
        public AddProductCommand(string name, string description, double price, string image,int vendorId, int categoryId)
       {
           Name = name;
           Description = description;
           Price = price;
           Image = image;
           CategoryId = categoryId;
           VendorId = vendorId;

       }
    }
}
