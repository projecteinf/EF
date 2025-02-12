using System;
using static System.Console;

public record CreateUserDto(string Name, string Email)
{
    public User ToModel() => new User(Guid.NewGuid().ToString(), Name, Email);
}

public class User
{
    public string Id { get; }
    public string Name { get; }
    public string Email { get; }

    public User(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}

class Program
{
    static void Main()
    {
        var dto = new CreateUserDto("Joan", "joan@email.com");
        var user = dto.ToModel();

        WriteLine($"DTO: {dto}");
        WriteLine($"User: {user.Id}, {user.Name}, {user.Email}");
    }
}
