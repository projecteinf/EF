Fitxer: DTO/CreateUserDTO.cs
```CSharp

public record CreateUserDTO(string Name, string Email)
{
    public User ToModel() => new User(Guid.NewGuid().ToString(), Name, Email);
}

```
Fitxer: Model/User.cs
```CSharpentenc que
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
```
Fitxer: Services/UserService.cs
```CSharp
public class UserService {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(CreateUserDTO dto)
    {
        var newUser = dto.ToModel();
        await _userRepository.SaveAsync(newUser);
        return newUser;
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await _userRepository.GetByIdAsync(id);
    }
}

```

Fitxer: Interfaces/IUserRepository.cs
```CSharp
public interface IUserRepository
{
    Task SaveAsync(User user);
    Task<User?> GetByIdAsync(string id);
}

```

Fitxer: DB/InMemoryUserRepository.cs
```CSharp
public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public async Task SaveAsync(User user)
    {
        _users.Add(user);
        await Task.CompletedTask;
    }

    public Task<User?> GetByIdAsync(string id)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
    }
}
```

Fitxer: Controllers/UserController.cs (API)
```CSharp
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto)
    {
        
        var newUser = await _userService.CreateUserAsync(dto);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        // Simulem la recerca de l'usuari per ID
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
```

Probablement en un futur podríem tenir més classes de tipus record . Per exemple:

Fitxer: DTO/UserDto.cs
```CSharp

public record CreateUserDTO(string Name, string Email)
{
    public User ToModel() => new User(Guid.NewGuid().ToString(), Name, Email);
}

public record UpdateUserDTO(string Id, string Name, string Email); // pot implementar mètode ToModel() o altres com CreateUserDTO
public record UserResponseDTO(string Id, string Name, string Email);

```