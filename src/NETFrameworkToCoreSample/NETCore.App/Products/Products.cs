using System.Collections.Generic;
using NETCore.App.Contracts;

namespace NETCore.App.Products
{
    public class Products
    {
        private readonly List<ProductDto> _products = new List<ProductDto>();

        public void Add(ProductDto product)
        {
            _products.Add(product);
        }

        public List<ProductDto> GetAll()
        {
            return _products;
        }
    }
}