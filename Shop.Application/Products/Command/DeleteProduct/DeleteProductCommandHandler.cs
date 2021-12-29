using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.DataAccess;
using Shop.Domain.Exseption;
using Shop.Domain.Models;

namespace Shop.Application.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        
        private readonly ApplicationDbContext _db;
        public DeleteProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
          var result=await _db.Products.FindAsync(request.ProductId);
          if (result is null)
          {
              throw new NotFoundException(nameof(Product), request.ProductId);
          }

           _db.Products.Remove(result);

           await _db.SaveChangesAsync(cancellationToken);

          return Unit.Value;//Теперь, с точки зрения MediatR, значение необходимо вернуть. В случае отсутствия значения вы можете использовать Unit

        }
    }
}
