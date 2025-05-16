using DemoApi.Models;
using DemoApi.Models.PersonDto;
using MediatR;

namespace DemoApi.Queries
{
    public class GenericQueries
    {
        public record AddPersonQuery<TModel>(AddPersonDto Person) : IModelRequest<TModel>;
        public record DeletePersonQuery<TModel>(int Id) : IModelRequest<TModel>;
        public record GetByIdQuery<TModel>(int Id) : IModelRequest<TModel>;
        public record GetPersonListQuery<TModel> : IModelRequest<List<TModel>>;
        public record UpdatePersonQuery<TModel>(int Id, UpdatePersonDto Person) : IModelRequest<TModel>;
    }
}
