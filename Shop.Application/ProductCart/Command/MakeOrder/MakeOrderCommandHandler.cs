using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Command.MakeOrder
{
    public class MakeOrderCommandHandler : IRequestHandler<MakeOrderCommand, bool>
    {
        private readonly ApplicationDbContext _db;

        public MakeOrderCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var result =  _db.Carts.Include(x => x.Products).Where(x => x.UserId == request.UserId && x.OrderId==null);
            if (!result.Any())
            {
                return false;
            }

            var totalSum = 0;
            foreach (var item in result)
            {
                totalSum += item.Quantity * (int)item.Products.Price;
            }

            var order = new Order(totalSum, request.UserId);
            _db.Orders.Add(order);
            await _db.SaveChangesAsync(cancellationToken);
            await result.ForEachAsync(x => x.SetOrderId(order.Id),cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
