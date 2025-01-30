# Convenció de noms

## General

✔️ Utilitzar noms que siguin significatius i descriptius
✔️ Utilitzar noms fàcils de llegir/entendre encara que siguin més llargs: ( `GetCustomerName` vs `GetCustNm` )
❌ No utilitzar caracters especials com ara $, @, %, etc.
❌ No utilitzar noms de variables que siguin o referencïin noms de tipus
❌ No utilitzar noms que es corresponguin amb paraules clau del llenguatge

## Format noms

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

