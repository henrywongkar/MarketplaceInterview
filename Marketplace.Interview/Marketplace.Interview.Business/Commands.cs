using Marketplace.Interview.Business.Basket;
using Marketplace.Interview.Business.Core;

namespace Marketplace.Interview.Business
{
    public interface IRemoveFromBasketCommand : ICommand<int, bool>{}
    public interface IAddToBasketCommand : ICommand<AddToBasketRequest, AddToBasketResponse>{}
}