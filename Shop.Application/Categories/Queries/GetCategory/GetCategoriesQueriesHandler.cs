using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Categories.Queries;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Categories.Queries
{
   public class GetCategoriesQueriesHandler : IRequestHandler<GetCategoriesQueries, CategoriesViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetCategoriesQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public  Task<CategoriesViewModel> Handle(GetCategoriesQueries request, CancellationToken cancellationToken)
        {

            return Task.FromResult(new CategoriesViewModel()
            {
                Categories = _db.Categories.ToArray()
            });
        }
    }
}
