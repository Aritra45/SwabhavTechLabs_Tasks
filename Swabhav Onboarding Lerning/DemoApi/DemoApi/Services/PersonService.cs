using System.Collections.Generic;
using DemoApi.Interfaces.IRepositoryes;
using DemoApi.Interfaces.IServices;
using DemoApi.Models;
using DemoApi.Models.PersonDto;

namespace DemoApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<PersonModel> _repository;
        public PersonService(IGenericRepository<PersonModel> genericRepository)
        {
            _repository = genericRepository;
        }

        public async Task<PersonModel> Add(AddPersonDto addPersonDto)
        {
            var user = new PersonModel
            {
                FirstName = addPersonDto.FirstName,
                LastName = addPersonDto.LastName,
            };

            await _repository.AddAsync(user);
            return user;
        }

        public async Task<List<PersonModel>> GetAll()
        {
            var users = await _repository.GetAllAsync();
            return users.ToList();
        }

        public PersonModel GetById(int id)
        {
            var user = _repository.GetByID(id);
            return user;
        }

        public PersonModel Update(int id, UpdatePersonDto updatePersonDto)
        {
            var user = _repository.GetByID(id);
            if(user != null)
            {
                user.LastName = updatePersonDto.LastName;

                _repository.Update(user);
                return user;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<PersonModel> Delete(int userId)
        {
            var user = _repository.GetByID(userId);
            if (user != null)
            {
                _repository.Delete(user);
                return user;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
