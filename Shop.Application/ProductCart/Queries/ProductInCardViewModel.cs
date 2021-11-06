using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Queries
{
     public class ProductInCardViewModel
     {
         public Product[] ProductFromCart { get; set; }

         public double FullCost => ProductFromCart.Sum(x => x.Price);//todo:считать продукты у которых фглаг истина

     }
}
