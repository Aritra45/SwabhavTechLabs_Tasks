using DemoApi.Interfaces.IServices;
using DemoApi.Models;
using DemoApi.Models.PersonDto;
using DemoApi.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApi.Handlers
{
    public class GenericHandler<TService, TModel> :
        IRequestHandler<GenericQueries.AddPersonQuery<TModel>, TModel>,
        IRequestHandler<GenericQueries.DeletePersonQuery<TModel>, TModel>,
        IRequestHandler<GenericQueries.GetByIdQuery<TModel>, TModel>,
        IRequestHandler<GenericQueries.GetPersonListQuery<TModel>, List<TModel>>,
        IRequestHandler<GenericQueries.UpdatePersonQuery<TModel>, TModel>
        where TService : IPersonService
        where TModel : PersonModel
    {
        private readonly TService _service;

        public GenericHandler(TService service)
        {
            _service = service;
        }

        public async Task<TModel> Handle(GenericQueries.AddPersonQuery<TModel> request, CancellationToken cancellationToken)
        {
            return (TModel)await _service.Add(request.Person);
        }

        public async Task<TModel> Handle(GenericQueries.DeletePersonQuery<TModel> request, CancellationToken cancellationToken)
        {
            return (TModel)await _service.Delete(request.Id);
        }

        public Task<TModel> Handle(GenericQueries.GetByIdQuery<TModel> request, CancellationToken cancellationToken)
        {
            return Task.FromResult((TModel)_service.GetById(request.Id));
        }

        public async Task<List<TModel>> Handle(GenericQueries.GetPersonListQuery<TModel> request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAll();
            return result.Cast<TModel>().ToList();
        }

        public Task<TModel> Handle(GenericQueries.UpdatePersonQuery<TModel> request, CancellationToken cancellationToken)
        {
            var result = _service.Update(request.Id, request.Person);
            return Task.FromResult((TModel)result);
        }
    }
}
