using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETCore.App.Contracts;

namespace NETFramework.App
{
    class Program
    {
        static void Main(string[] args)
        {
            INewAppGateway gateway = new NewAppGateway("http://localhost:5000", new UserContextMock
            {
                UserId = Guid.Parse("cd5c2ae8-6939-45b1-b07d-fdfb483b337d")
            });

            Console.WriteLine("Adding first product");
            gateway.ExecuteCommand(new AddProductCommand("Product 1"));
            Console.WriteLine("Adding second product");
            gateway.ExecuteCommand(new AddProductCommand("Product 2"));
            Console.WriteLine("Adding third product");
            gateway.ExecuteCommand(new AddProductCommand("Product 3"));

            Console.WriteLine("Get all products");
            var products = gateway.ExecuteQuery(new GetProductsQuery());

            foreach (var productDto in products)
            {
                Console.WriteLine($"Product name : {productDto.Name} for user: {productDto.UserId}");
            }

            Console.ReadKey();
        }
    }
}
