using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;

namespace Shop.Application.Categories.Command.EditCategory
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public EditCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =  await _db.Categories.FindAsync(request.Id);
            if (category is null)
            {
                //todo: исключение 
            }
            else
            {
                category.SetName(request.Name);
               
            }

            await _db.SaveChangesAsync(cancellationToken);
             return  Unit.Value;
        }
    }
}
