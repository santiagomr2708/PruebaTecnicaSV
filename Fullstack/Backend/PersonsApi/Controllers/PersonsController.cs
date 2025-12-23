using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PersonsApi.Dtos;
using PersonsApi.Repositories;

namespace PersonsApi.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonsController : ControllerBase
{
    private readonly IPersonRepository _repo;
    private readonly IValidator<PersonCreateDto> _createValidator;
    private readonly IValidator<PersonUpdateDto> _updateValidator;

    public PersonsController(IPersonRepository repo,
                             IValidator<PersonCreateDto> createValidator,
                             IValidator<PersonUpdateDto> updateValidator)
    {
        _repo = repo;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    // Crear una persona
    [HttpPost]
    public IActionResult Create([FromBody] PersonCreateDto dto)
    {
        var result = _createValidator.Validate(dto);
        if (!result.IsValid) return BadRequest(result.Errors);
        var created = _repo.Add(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // Listar personas o buscar por nombre (?name=valor)
    [HttpGet]
    public IActionResult List([FromQuery] string? name)
    {
        var data = string.IsNullOrWhiteSpace(name) ? _repo.GetAll() : _repo.FindByName(name!);
        return Ok(data);
    }

    // Obtener por id
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var person = _repo.GetById(id);
        return person is null ? NotFound() : Ok(person);
    }

    // Actualizar persona
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] PersonUpdateDto dto)
    {
        var result = _updateValidator.Validate(dto);
        if (!result.IsValid) return BadRequest(result.Errors);
        return _repo.Update(id, dto) ? NoContent() : NotFound();
    }

    // Eliminar persona
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        return _repo.Delete(id) ? NoContent() : NotFound();
    }
}
