namespace PersonsApi.Dtos;

public class PersonCreateDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Document { get; set; } = default!;
}
