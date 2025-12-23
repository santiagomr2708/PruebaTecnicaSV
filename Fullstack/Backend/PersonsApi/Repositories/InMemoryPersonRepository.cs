using PersonsApi.Models;
using PersonsApi.Dtos;

namespace PersonsApi.Repositories;

public class InMemoryPersonRepository : IPersonRepository
{
    private readonly List<Person> _people = new();

    public IEnumerable<Person> GetAll() => _people;

    public IEnumerable<Person> FindByName(string name)
    {
        var term = name.Trim().ToLowerInvariant();
        return _people.Where(p =>
            ($"{p.FirstName} {p.LastName}").ToLowerInvariant().Contains(term));
    }

    public Person? GetById(Guid id) => _people.FirstOrDefault(p => p.Id == id);

    public Person Add(PersonCreateDto dto)
    {
        var p = new Person
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Document = dto.Document
        };
        _people.Add(p);
        return p;
    }

    public bool Update(Guid id, PersonUpdateDto dto)
    {
        var p = GetById(id);
        if (p is null) return false;
        p.FirstName = dto.FirstName;
        p.LastName = dto.LastName;
        p.Email = dto.Email;
        return true;
    }

    public bool Delete(Guid id)
    {
        var p = GetById(id);
        if (p is null) return false;
        _people.Remove(p);
        return true;
    }
}
