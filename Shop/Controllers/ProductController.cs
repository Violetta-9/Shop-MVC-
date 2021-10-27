using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Queries;
using Shop.Application.Products.Queries.GetProductById;
using Shop.Application.Products.Queries.GetProducts;
using Shop.Application.Vendors.Queries;
using Shop.DataAccess;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _db;
        public ProductController(IMediator mediator,ApplicationDbContext db)
        {
            _mediator = mediator;
            _db = db;
        }
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

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int productId)
        {
            var product = await _mediator.Send(new GetProductByIdQueries(productId));
            
            return View(product);
        }

        
     
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
