using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Exseption;
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
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            product.SetProductName(request.Name);
            product.SetProductDiscription(request.Description);
            product.SetProductPrice(request.Price);
            product.SetProductCategory(request.CategoryId);
            product.SetProductVendor(request.VendorId);
        
            await _db.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
