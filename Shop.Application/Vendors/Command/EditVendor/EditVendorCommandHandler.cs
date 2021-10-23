using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;

namespace Shop.Application.Vendors.Command.EditVendor
{
    public class EditVendorCommandHandler : IRequestHandler<EditVendorCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public EditVendorCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(EditVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _db.Vendors.FindAsync(request.Id);
            if (vendor is null)
            {
                //todo: исключение 

            }
            else
            {
              vendor.SetName(request.Name);
              vendor.SetDescription(request.Description);

            }
            await _db.SaveChangesAsync(cancellationToken);
           return Unit.Value;
        }
    }
}
