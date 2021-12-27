using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Shop.DataAccess;
using Shop.Domain.Exseption;
using Shop.Domain.Models;

namespace Shop.Application.Vendors.Command.DeleteVendor
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public DeleteVendorCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<Unit> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor =  await _db.Vendors.FindAsync(request.Id);
            if (vendor is null)
            {
                throw new NotFoundException(nameof(Vendor), request.Id);

            }
            else
            {

                _db.Vendors.Remove(vendor);
                await _db.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
