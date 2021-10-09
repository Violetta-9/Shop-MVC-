using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using Shop.DataAccess;
using Shop.Domain.Models;
using ILogger = Serilog.ILogger;

namespace Shop.Application.Products.Command.AddProducts
{
    class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        
        public AddProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger= Log.ForContext<AddProductCommandHandler>();//регистор, который будеть дополнять журнальные записи, как указано
        }
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Image, request.VendorId, request.CategoryId);
            _db.Products.Add(product);

            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Продукт {0} успешно добавлен", product.Id);
            return product.Id;

        }
    }
}
