using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Queries;
using Shop.Application.ProductCart.Command;
using Shop.Application.ProductCart.Command.AddProductInCart;
using Shop.Application.ProductCart.Command.SubProductInCart;
using Shop.Application.ProductCart.Queries.GetQuantity;
using Shop.Application.Products.Queries.GetProductById;
using Shop.Application.Products.Queries.GetProducts;
using Shop.Application.Reviews.Queries.GetRatingAndReviewAboutProduct;
using Shop.Application.Vendors.Queries;
using Shop.DataAccess;
using Shop.Domain.Models;
using Shop.Filter1;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;
        public ProductController(IMediator mediator, UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _manager = manager;

        }
        [Authorize]
        public  async Task<ActionResult> Index()
        {
            var vendor = await  _mediator.Send(new GetVendorQueries());
            var category =  await _mediator.Send(new GetCategoriesQueries());
            var product = await _mediator.Send(new GetProductQueries());
            var productmodel = new CommonViewModel()
            {
                Vendor = vendor,
                Category = category,
                Product = product
            };
            return View(productmodel);

        }

        [Authorize]
        public async Task<ActionResult> Details(int productId)
        {
            var user = await _manager.GetUserAsync(User);
            var product = await _mediator.Send(new GetProductByIdQueries(productId));
            var review = await _mediator.Send(new GetRatingAndReviewAboutProductCommand(productId));

            var productAndReview = new ProductAndReviewViewModel()
            {
                User=user,
                Review = review,
                Product = product,
            };
            
            return View(productAndReview);
        }


        [Authorize]
        public async Task<ActionResult> Find(int vendorId,int categoryId,int sort)
        {
            var product = (await _mediator.Send(new GetProductQueries())).Products;
            if (vendorId != 0)
            {
                product = product.Where(x => x.Vendors.Id == vendorId).ToArray();
            }

            if (categoryId != 0)
            {
                product = product.Where(x => x.Categories.Id == categoryId).ToArray();
            }

            if (sort == 1)
            {
                product = product.OrderByDescending(x => x.Price).ToArray();
            }

            if (sort == -1)
            {
                product = product.OrderBy(x => x.Price).ToArray();
            }

            var category = await _mediator.Send(new GetCategoriesQueries());
            var vendor = await _mediator.Send(new GetVendorQueries());
            var common = new CommonViewModel()
            {
                Product = new ProductViewModel() {Products = product},
                Vendor = vendor,
                Category = category
            };
            return View("Index", common);

        }
        [Filter]
        [HttpPost]
        public async Task<int> SubProductInCart(int id, int quentity)
        {
            var user = await _manager.GetUserAsync(User);
            await _mediator.Send(new SubProductInCartCommand(id,quentity,user.Id));
            var result = await _mediator.Send(new GetQuantityQueries(user.Id));

            return result;
        }
        [Authorize]
        [HttpPost]
        public async Task<int> AddProductInCart(int id,int quentity)
        {
            var user = await _manager.GetUserAsync(User);
            await _mediator.Send(new AddProductInCartCommand(id, user.Id, quentity));
            var result = await _mediator.Send(new GetQuantityQueries(user.Id));

            return result;
        }


    }
}
