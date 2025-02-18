# Generics
Utilitzem "generics", simbolitzats amb la lletra T, quan volem crear una classe  que es pugui utilitzar amb qualsevol tipus. Per exemple, la classe List de C# està implementada utilitzant generics: podem utilitzar la classe amb qualsevol classe de C# o amb la implementació pròpia de la classe.
Podem utilitzar "generics" en la codificació de la classe o en qualsevol mètode.
## Avantatges
✔️ Els genèrics fan el codi més flexible i reutilitzable, reduint duplicació i errors de tipus. 
## Classe genèrica
### Exemple classe genèrica
```CSharp
public class Stack<T>
{
    private List<T> _elements = new List<T>();

    public void Push(T item) => _elements.Add(item);
    
    public T Pop()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        T item = _elements[^1]; // Agafa l'últim element
        _elements.RemoveAt(_elements.Count - 1);
        return item;
    }
}
```
### Exemple interface genèrica
```CSharp
public interface IRepository<T>
{
    void Add(T item);
    T GetById(int id);
}
public class UserRepository : IRepository<User>
{
    private List<User> _users = new List<User>();
    public void Add(User user) => _users.Add(user);   
    public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
}
```
## Mètode genèric
En una classe, no genèrica, podem tenir un o varis mètodes que utilitzen genèrics com a paràmetre
### Exemple mètode genèric
```CSharp
public static class SwapHelper
{
    public static void Intercanviar<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}
```