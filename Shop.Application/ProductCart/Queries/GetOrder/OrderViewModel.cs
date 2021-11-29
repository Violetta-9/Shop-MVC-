using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Queries.GetOrder
{
     public class OrderViewModel
    {
        public Cart[] ProductInCart { get; set; }
    }
}
