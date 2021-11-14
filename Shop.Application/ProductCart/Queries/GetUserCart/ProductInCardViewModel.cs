using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Queries.GetUserCart
{
     public class ProductInCardViewModel
     {
         public  int ProductId { get; set; }
         public int CartId { get; set; }
        public double Priece { get; set; }
         public string Image { get; set; }
         public string Name { get; set; }
        public int Quantity { get; set; }
         public double FullCost { get; set; }//todo:считать продукты у которых фглаг истина

     }
}
