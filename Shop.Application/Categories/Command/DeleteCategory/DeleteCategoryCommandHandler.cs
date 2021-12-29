using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Exseption;
using Shop.Domain.Models;


namespace Shop.Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public DeleteCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FindAsync(request.Id);
            if (category is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
            else
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync(cancellationToken);
              
            }
            return Unit.Value;
        }
    }
}
