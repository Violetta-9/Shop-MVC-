using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Application.Products.Queries.GetProducts;
using Shop.DataAccess;
using Shop.Filter1;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db,IMediator mediator)
        {
            _logger = logger;
            db = _db;
            _mediator = mediator;

        }
        [Filter]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
             
            var product =  await _mediator.Send(new GetProductQueries());

            return View(product);
        }

        public ActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
