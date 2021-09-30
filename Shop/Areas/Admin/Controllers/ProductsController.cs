using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Application.Products.Command.AddProducts;
using Shop.Application.Products.Command.DeleteProduct;
using Shop.Application.Products.Queries.GetProducts;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _appEnvironment;


        public ProductsController(IMediator mediator,IWebHostEnvironment app)
        {
            _mediator = mediator;
            _appEnvironment = app;
        }
        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductQueries());
            return View(products);
        }


        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        // IFormFile Представляет файл, отправленный с HttpRequest.
        public async Task<ActionResult> Create(string title,string description,double price,IFormFile file)
        {
            if (file is null)
            {
                return RedirectToAction("Index", "Products");
            }

            var path = Path.Combine(_appEnvironment.WebRootPath, "images","Products",file.Name);

            using (var fileforFileStream = new FileStream(path, FileMode.Create))
            {
                //Асинхронно считывает байты из текущего потока и записывает их в другой поток.
                await file.CopyToAsync(fileforFileStream);
            }

             await _mediator.Send(new AddProductCommand(title,description,price,file.Name));

            return RedirectToAction("Index", "Products");


        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ProductsController/Delete/5
       
        public async  Task<ActionResult> Delete(int productId)
        {
               await _mediator.Send(new DeleteProductCommand(productId));
               
               return RedirectToAction("Index","Products");
        
        }
    }
}
