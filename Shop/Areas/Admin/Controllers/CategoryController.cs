using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Command;
using Shop.Application.Categories.Command.DeleteCategory;
using Shop.Application.Categories.Queries;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]//класс или метод требует указанной авторизации
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
     
        public async Task<ActionResult> Index()
        {
            var categories = await _mediator.Send(new GetCategoriesQueries());
            return View(categories);
        }

       
   
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(string categoryName)
        {
            await _mediator.Send(new AddCategoryCommand(categoryName));
            return RedirectToAction("Index", "Category");
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
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

        [HttpPost]
        public async Task Delete(int categoryId)
        {
            await _mediator.Send(new DeleteCategoryCommand(categoryId));
            
        }
    }
}
