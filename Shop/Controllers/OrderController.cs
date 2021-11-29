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

using Shop.Application.ProductCart.Command.DeleteProductInCart;
using Shop.Application.ProductCart.Command.MakeOrder;
using Shop.Application.ProductCart.Queries.GetOrder;
using Shop.Domain.Models;

namespace Shop.Controllers
{
   
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        private readonly UserManager<ShopUser> _manager;

        public OrderController(IMediator mediator, UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _manager = manager;
        }
        [Authorize]
        public async Task<ActionResult> GetOrder()
        {
            var user = await _manager.GetUserAsync(User);
            var result = _mediator.Send(new GetOrderQueries(user.Id)).Result;
            return View(result);

        }

        [Authorize]

        public async Task<ActionResult> MakeOrder()
        {
            var user = await _manager.GetUserAsync(User);
            if (await _mediator.Send(new MakeOrderCommand(user.Id)))
            {
                //await _mediator.Send(new DeleteAllProductCommand(user.Id));
                return View("MakeOrder");

            }
            else
            {
                return View("ErrorOrder");//todo: что-то пошло не так

            }

        }
    }
}
