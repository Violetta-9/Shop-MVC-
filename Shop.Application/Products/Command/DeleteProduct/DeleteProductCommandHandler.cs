using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ILogger _logger;
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
              //Todo: исключение, которое говорит нам что данного продукта нет в бд
          }

            _db.Products.Remove(result);

           await _db.SaveChangesAsync(cancellationToken);

          return Unit.Value;//Теперь, с точки зрения MediatR, значение необходимо вернуть. В случае отсутствия значения вы можете использовать Unit

        }
    }
}
