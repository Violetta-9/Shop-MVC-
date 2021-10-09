using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.DataAccess;

namespace Shop.Application.Products.Queries.GetProducts
{
  public   class GetProductsQueriesHandler : IRequestHandler<GetProductQueries, ProductViewModel>
    {
        private readonly ApplicationDbContext _db;
     
        public GetProductsQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public Task<ProductViewModel> Handle(GetProductQueries request, CancellationToken cancellationToken)
        {

            return Task.FromResult(new ProductViewModel()//Создает задачу <TResult>, которая успешно завершена с указанным результатом.
            {
                Products = _db.Products.ToArray()
            });
        }
    }
}
