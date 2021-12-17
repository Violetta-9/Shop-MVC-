using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Reviews.Queries.GetRatingAndReviewAboutProduct
{
    public class GetRatingAndReviewAboutProductCommandHandler : IRequestHandler<GetRatingAndReviewAboutProductCommand, ReviewViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetRatingAndReviewAboutProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<ReviewViewModel> Handle(GetRatingAndReviewAboutProductCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Reviews.Where(i => i.ProductId == request.ProductId).ToArray();
            return Task.FromResult(new ReviewViewModel()//Создает задачу <TResult>, которая успешно завершена с указанным результатом.
            {
                Reviews =result
            });
        }
    }
}
