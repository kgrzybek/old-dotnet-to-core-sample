using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NETCore.App.Contracts;

namespace NETCore.App.Products
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly Products _products;

        private readonly IUserContext _userContext;

        public AddProductCommandHandler(Products products, IUserContext userContext)
        {
            _products = products;
            _userContext = userContext;
        }

        public Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _products.Add(new ProductDto
            {
                Name = request.Name,
                UserId = _userContext.UserId.Value
            });

            return null;
        }
    }
}