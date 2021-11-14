using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueriesHandler : IRequestHandler<GetProductByIdQueries, Product>
    {
        private readonly ApplicationDbContext _db;

        public GetProductByIdQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public  async Task<Product> Handle(GetProductByIdQueries request, CancellationToken cancellationToken)
        {
            var result = await _db.Products.Include(x => x.Categories).Include(x => x.Vendors)
                .SingleOrDefaultAsync(x => x.Id == request.ProductId);
             if (result is null)
             {
                //Todo: исключение которое говорит что данного продукта нет 
             }

             return result;

        }
    }
}
