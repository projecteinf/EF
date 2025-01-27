# Referència web

https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/


# Convenció de noms

* PascalCasing: mètodes i propietats públiques, tipus i noms d'espais de noms que consisteixen en múltiples paraules
* camelCasing: noms de paràmetres

| Identifier   | Casing  | Example                                                                                      |
|--------------|---------|----------------------------------------------------------------------------------------------|
| Namespace    | Pascal  | `namespace System.Security { ... }`                                                         |
| Type         | Pascal  | `public class StreamReader { ... }`                                                         |
| Interface    | Pascal  | `public interface IEnumerable { ... }`                                                     |
| Method       | Pascal  | `public class Object { public virtual string ToString(); }`                                 |
| Property     | Pascal  | `public class String { public int Length { get; } }`                                        |
| Event        | Pascal  | `public class Process { public event EventHandler Exited; }`                                |
| Field        | Pascal  | `public class MessageQueue { public static readonly TimeSpan InfiniteTimeout; }`            |
|              |         | `public struct UInt32 { public const Min = 0; }`                                            |
| Enum value   | Pascal  | `public enum FileMode { Append, ... }`                                                      |
| Parameter    | Camel   | `public class Convert { public static int ToInt32(string value); }`                         |

