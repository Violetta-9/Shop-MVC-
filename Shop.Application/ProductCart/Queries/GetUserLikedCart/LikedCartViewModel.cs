using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Queries.GetUserLikedCart
{
    public  class LikedCartViewModel
    {
        public int LikedId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public  string Image { get; set; }
    }
}
