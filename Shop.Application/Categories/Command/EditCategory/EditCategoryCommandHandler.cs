using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Exseption;
using Shop.Domain.Models;

namespace Shop.Application.Categories.Command.EditCategory
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Category>
    {
        private readonly ApplicationDbContext _db;

        public EditCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =  await _db.Categories.FindAsync(request.Id);
            if (category is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);

            }
            else
            {
                category.SetName(request.Name);
               
            }

            await _db.SaveChangesAsync(cancellationToken);
             return  category;
        }
    }
}
