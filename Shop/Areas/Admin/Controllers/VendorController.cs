using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Vendors.Command;
using Shop.Application.Vendors.Command.DeleteVendor;
using Shop.Application.Vendors.Command.EditVendor;
using Shop.Application.Vendors.Queries;
using Shop.Application.Vendors.Queries.GetCategoryById;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VendorController : Controller
    {
        private readonly IMediator _mediator;

        public VendorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult>  Index()
        {
            var vendors =  await _mediator.Send(new GetVendorQueries());
            return View(vendors);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string nameVendor,string descriptionVendor)
        {
            await _mediator.Send(new AddVendorCommand(nameVendor, descriptionVendor));
            return RedirectToAction("Index", "Vendor");

        }

        // GET: VendorController/Edit/5
        public async Task<ActionResult>  Edit(int vendorId)
        {
            var vendor = await _mediator.Send(new GetVendorByIdQueries(vendorId));
            return View(vendor);
        }

        // POST: VendorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int vendorId,string vendorName,string vendorDescription)
        {
            await _mediator.Send(new EditVendorCommand(vendorId, vendorName, vendorDescription));
            return RedirectToAction("Index", "Vendor");
        }


       
        public async Task Delete(int vendorId)
        {
            await _mediator.Send(new DeleteVendorCommand(vendorId));
            
        }
    }
}
