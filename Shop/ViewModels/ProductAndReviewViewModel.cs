using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.Products.Queries.GetProducts;
using Shop.Application.Reviews.Queries.GetRatingAndReviewAboutProduct;
using Shop.Application.Reviews.Queries.GetReviewByProductId;
using Shop.Domain.Models;

namespace Shop.ViewModels
{
    public class ProductAndReviewViewModel
    {
        public ReviewViewModel Review { get; set; }
        public Product Product { get; set; }
        public ShopUser User { get; set; }
    
    }
}
