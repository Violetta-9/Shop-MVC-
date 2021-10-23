using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Shop.DataAccess;

namespace Shop.Application.Vendors.Queries
{
     public  class GetVendorsQueriesHandler : IRequestHandler<GetVendorQueries, VendorsViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetVendorsQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<VendorsViewModel> Handle(GetVendorQueries request, CancellationToken cancellationToken)
        {

            return  Task.FromResult(new VendorsViewModel()
            {
                Vendors = _db.Vendors.ToArray()
            });

        }
    }
}
