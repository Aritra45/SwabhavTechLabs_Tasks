using DemoApi.Models;
using DemoApi.Models.PersonDto;

namespace DemoApi.Interfaces.IServices
{
    public interface IPersonService
    {
        public Task<List<PersonModel>> GetAll();

        public PersonModel GetById(int id);
        public Task<PersonModel> Add(AddPersonDto addPersonDto);

        public PersonModel Update(int id, UpdatePersonDto updatePersonDto);
        public Task<PersonModel> Delete(int userId);
    }
}
