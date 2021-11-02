using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Reviews.Queries.GetReviewByProductId
{
    class GetReviewsByProductIdQueriesHandler : IRequestHandler<GetReviewsByProductIdQueries, ReviewViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetReviewsByProductIdQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public  Task<ReviewViewModel> Handle(GetReviewsByProductIdQueries request, CancellationToken cancellationToken)
        {
            var result =  _db.Reviews.Include(x => x.Product).Where(x=>x.ProductId==request.ProductId).ToArray();
            return Task.FromResult(new ReviewViewModel
            {
                Reviews = result
            });
        }
    }
}
