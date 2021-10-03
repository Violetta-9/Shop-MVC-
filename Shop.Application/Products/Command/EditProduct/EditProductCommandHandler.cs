﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Products.Command.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Product>
    {
        private readonly ApplicationDbContext _db;

        public EditProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(request.ProductId);
           
            if (product is null)
            {
                //Todo:вызвать исключение 
            }

            product.SetProductName(request.Name);
            product.SetProductDiscription(request.Description);
            product.SetProductPrice(request.Price);
        
            await _db.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
