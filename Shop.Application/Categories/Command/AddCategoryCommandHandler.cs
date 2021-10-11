using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Categories.Command
{
    class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, int>
    {
        private readonly ApplicationDbContext _db;
        public AddCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
             _db.Categories.Add(category);
            await _db.SaveChangesAsync(cancellationToken);
            return category.Id;


        }
    }
}
