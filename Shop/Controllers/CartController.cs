using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductCart.Command.DeleteProductInCart;
using Shop.Application.ProductCart.Queries;
using Shop.Application.ProductCart.Queries.GetQuantity;
using Shop.Application.ProductCart.Queries.GetUserCart;
using Shop.Domain.Models;
using Shop.Filter1;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;

        public CartController(IMediator mediator,UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _manager = manager;
        }
      [Authorize]
        public  async Task<ActionResult> Index()
        {
            
            var user = await _manager.GetUserAsync(User);
            var result = await _mediator.Send(new GetProductFromTheCartQueries(user.Id));
           
            return View(result);
        }
        [HttpPost]
        public async Task<int> Quantity()
        {

            var user = await _manager.GetUserAsync(User);
            if (user == null)
            {
                return 0;
            }
            else
            {
                var result = await _mediator.Send(new GetQuantityQueries(user.Id));

                return result;
            }
        }
        [Filter]
        [Authorize]
        [HttpPost]
        public async Task<int>  Delete(int id)
        {
            await _mediator.Send(new DeleteProductInCartCommand(id));
            var user = await _manager.GetUserAsync(User);
            var result = await _mediator.Send(new GetQuantityQueries(user.Id));

            return result;
        }

    }
}
