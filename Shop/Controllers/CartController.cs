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
using Shop.Application.ProductCart.Queries.GetUserCart;
using Shop.Domain.Models;
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


        [Authorize]
        [HttpPost]
        public async Task  Delete(int id)
        {
            await _mediator.Send(new DeleteProductInCartCommand(id));
        }

    }
}
