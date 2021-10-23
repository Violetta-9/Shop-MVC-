using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Vendors.Queries.GetCategoryById
{
    public class GetVendorByIdQueriesHandler : IRequestHandler<GetVendorByIdQueries, Vendor>
    {
        private readonly ApplicationDbContext _db;

        public GetVendorByIdQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Vendor> Handle(GetVendorByIdQueries request, CancellationToken cancellationToken)
        {
            var vendor = await _db.Vendors.FindAsync(request.Id);
            return vendor;

        }
    }
}
