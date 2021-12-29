using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.DataAccess;
using Shop.Domain.Exseption;
using Shop.Domain.Models;

namespace Shop.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryByIdCommand, Category>
    {
        private readonly ApplicationDbContext _db;
        public GetCategoryByIdCommandHandler(ApplicationDbContext db)
        {
            _db = db;

        }
        public async Task<Category> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
           var category= await _db.Categories.FindAsync(request.Id);
           if (category is null)
           {
               throw new NotFoundException(nameof(Category), request.Id);
           }

           return category;
           
        }
    }

}
