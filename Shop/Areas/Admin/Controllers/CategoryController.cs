using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shop.Application.Categories.Command;
using Shop.Application.Categories.Command.DeleteCategory;
using Shop.Application.Categories.Command.EditCategory;
using Shop.Application.Categories.Queries;
using Shop.Application.Categories.Queries.GetCategoryById;

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

        [HttpGet]
        public async Task<ActionResult> Edit(int categoryid)
        {
            var category= await _mediator.Send(new GetCategoryByIdCommand(categoryid));
            return View(category);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]// предназначен для противодействия подделке межсайтовых запросов, производя верификацию токенов при обращении к методу действия.
        public  async Task<ActionResult> Edit(int categoryId, string categoryName)
        {
            await _mediator.Send(new EditCategoryCommand(categoryName, categoryId));
            return RedirectToAction("Index", "Category");
        }


        public async Task Delete(int categoryId)
        {
            await _mediator.Send(new DeleteCategoryCommand(categoryId));
            
        }
    }
}
