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
using Shop.Application.Categories.Queries;
using Shop.Application.Products.Command.AddProducts;
using Shop.Application.Products.Command.DeleteProduct;
using Shop.Application.Products.Command.EditProduct;
using Shop.Application.Products.Queries.GetProductById;
using Shop.Application.Products.Queries.GetProducts;
using Shop.Application.Vendors.Queries;
using Shop.ViewModels;

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
        public async Task<IActionResult> Create()
        {
            var categories = await _mediator.Send( new GetCategoriesQueries());
            var vendors = await  _mediator.Send(new GetVendorQueries());
            return View("Create",new CreateProductViewModel()
            {
                Categories = categories, 
                Vendors=vendors
            });
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        // IFormFile Представляет файл, отправленный с HttpRequest.
        public async Task<ActionResult> Create(string title,string description,double price,IFormFile file,int categoryId,int vendorId)
        {
            if (file is null)
            {
                return RedirectToAction("Index", "Products");
            }

            var path = Path.Combine(_appEnvironment.WebRootPath, "images","Products",file.FileName);

            using (var fileforFileStream = new FileStream(path, FileMode.Create))
            {
                //Асинхронно считывает байты из текущего потока и записывает их в другой поток.
                await file.CopyToAsync(fileforFileStream);
            }

             await _mediator.Send(new AddProductCommand(title,description,price,file.FileName, vendorId,categoryId));

            return RedirectToAction("Index", "Products");


        }

        // GET: ProductsController/Edit/5
        [HttpGet]
        public  async Task<ActionResult> Edit(int productId)
        {
            var productById=await _mediator.Send(new GetProductByIdQueries(productId));
            var categories = await _mediator.Send(new GetCategoriesQueries());
            var vendors = await _mediator.Send(new GetVendorQueries());
            var data = new CreateProductViewModel() {Categories = categories, Vendors = vendors};
            return View("Edit",new EditProductViewModel
            {
                Product = productById,
                Data= data
            });
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]//Todo:посмотри что это 
        public async Task<ActionResult> Edit(int productId,string title, string description, double price,int vendorId,int categoryId)
        {
            
           await _mediator.Send(new EditProductCommand(productId,title, description, price,vendorId,categoryId));

           return RedirectToAction("Index", "Products");

        }

        // GET: ProductsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ProductsController/Delete/5
       [HttpGet]
        public async Task Delete(int productId)
        {
               await _mediator.Send(new DeleteProductCommand(productId));
             

        }
    }
}
