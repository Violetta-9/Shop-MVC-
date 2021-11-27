using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductCart.Command.AddProductInLikedCart;
using Shop.Application.ProductCart.Command.DeleteProductInLikedCart;
using Shop.Application.ProductCart.Queries.GetUserLikedCart;
using Shop.Domain.Models;

namespace Shop.Controllers
{
    public class LikedController : Controller
    {
        private readonly IMediator _mediator;
        private readonly  UserManager<ShopUser> _manager;
        public LikedController(IMediator mediator,UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _manager = manager;

        }
        public async Task<ActionResult> Index()
        {
            var user =  await _manager.GetUserAsync(User);
            var result = await _mediator.Send(new GetProductFromLikedCartQueries(user.Id));
            return View(result);
        }


        public async Task AddProductInLikedCart(int id)
        {
            var user = await _manager.GetUserAsync(User);
            await _mediator.Send(new AddProductInLikedCartCommand(id, user.Id));

        }




        [HttpPost]

        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteProductInLikedCartCommand(id));
        }

       
    }
}
