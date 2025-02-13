# Record

Record és una paraula reservada que ens permet crear un tipus de classe de forma més ràpida: menys codificació. 

## Exemple i funcionament

# Fitxer: DTO/CreateUserDTO.cs
```CSharp
public record CreateUserDTO(string Name, string Email)
{
    public User ToModel() => new User(Guid.NewGuid().ToString(), Name, Email);
}
```

El codi anterior crea un record anomenat CreateUserDTO, que defineix dues propietats: Name i Email, ambdues de tipus string. També defineix un mètode ToModel(), que retorna un objecte de tipus User.

## Funcionament intern

El compilador de C# ens simplifica la feina, fent que el record generi automàticament propietats immutables i implementi comparació per valor. Això fa que dues instàncies amb els mateixos valors siguin considerades iguals.

El compilador tradueix el record en una classe similar a la següent:

```CSharp
public class CreateUserDTO 
{
    public string Name { get; }
    public string Email { get; }

    public CreateUserDTO(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public User ToModel() => new User(Guid.NewGuid().ToString(), Name, Email);

    public override bool Equals(object? obj) => obj is CreateUserDTO dto && Name == dto.Name && Email == dto.Email;
    public override int GetHashCode() => HashCode.Combine(Name, Email);
    public override string ToString() => $"CreateUserDTO {{ Name = {Name}, Email = {Email} }}";

}
```
