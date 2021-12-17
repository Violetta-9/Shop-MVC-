using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Reviews.Command;
using Shop.Application.Reviews.Queries.GetRatingAndReviewAboutProduct;
using Shop.DataAccess.Migrations;
using Shop.Domain.Models;

namespace Shop.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;

        public ReviewController(IMediator mediator, UserManager<ShopUser> manager)
        {
            _manager = manager;
            _mediator = mediator;
        }

        public async Task<ActionResult> AddRating(int productId, string text, int rating)
        {
            var user = _manager.GetUserAsync(User).Result;
            await _mediator.Send(new AddReviewCommand(productId, text, rating, user.Id));
            return View("Success");
        }

        // GET: RatingController/Details/5
        public ActionResult GetReview(int productId)
        {
           var result= _mediator.Send(new GetRatingAndReviewAboutProductCommand(productId));
            return RedirectToAction("Details", "Product",new{productId=productId});
        }

        // GET: RatingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RatingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RatingController/Edit/5
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

        // GET: RatingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RatingController/Delete/5
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
