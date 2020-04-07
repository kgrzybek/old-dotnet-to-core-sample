using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NETCore.App.Contracts;

namespace NETCore.App.Products
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly Products _products;

        public GetProductsQueryHandler(Products products)
        {
            _products = products;
        }

        public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_products.GetAll());
        }
    }
}