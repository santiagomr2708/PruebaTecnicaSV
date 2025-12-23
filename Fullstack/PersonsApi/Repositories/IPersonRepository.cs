using PersonsApi.Models;
using PersonsApi.Dtos;

namespace PersonsApi.Repositories;

public interface IPersonRepository
{
    IEnumerable<Person> GetAll();
    IEnumerable<Person> FindByName(string name);
    Person? GetById(Guid id);
    Person Add(PersonCreateDto dto);
    bool Update(Guid id, PersonUpdateDto dto);
    bool Delete(Guid id);
}
