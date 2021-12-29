using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.ProductCart.Queries.GetUserCart
{
   public  class NewClassForProductInCartViewModel
   {
       public ProductInCardViewModel[] Products { get; set; }
       public double FullPriece => Products.Sum(x =>( x.Priece*x.Quantity));
       public int Quantity => Products.Sum(x => x.Quantity);
   }
}
