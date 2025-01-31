using System;
using static System.Console; // Good practice

string[] names = { "John", "Doe", "Jane", "Doe" };

foreach (string name in names)
{
    WriteLine(name);
}

/* 
Per utilitzar un foreach, la classe ha de tenir un mètode GetEnumerator() que retorna un objecte que implementa la interfície IEnumerator. 
Aquesta interfície conté els mètodes MoveNext() i Current. MoveNext() avança l'iterador a l'element següent i Current retorna l'element actual.
*/

IEnumerator enames = names.GetEnumerator();
while (enames.MoveNext())
{
    string name = (string)enames.Current; // Current is read-only!
    WriteLine($"{name} has {name.Length} characters.");
}
