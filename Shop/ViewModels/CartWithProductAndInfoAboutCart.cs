using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.ProductCart.Queries;
using Shop.Application.ProductCart.Queries.GetUserCart;

namespace Shop.ViewModels
{
    public class CartWithProductAndInfoAboutCart
    {
        public GetCartInfoViewModel InfoAboutCart;
        public ProductInCardViewModel ProductInCart;

    }
}
