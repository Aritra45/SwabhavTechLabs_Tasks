using MediatR;

namespace DemoApi.Queries
{
    public interface IModelRequest<TResponse> : IRequest<TResponse> { }

}
