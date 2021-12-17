using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Reviews.Command
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public AddReviewCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review(request.Text, request.Rating, request.UserId, request.ProductId);
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
