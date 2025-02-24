# Tipus string
* Immutable: quan el modifiquem generem una nova còpia.
* Fàcil d'utilitzar i llegible
```CSharp
string nom = "Maria";
string missatge = "Hola " + nom;
```
* Compatibilitat amb APIs
Normalment les APIs utilitzen aquest tipus de dada.  
# Tipus StringBuilder
* Mutable: els canvis es fan directament sobre la informació original, no hi ha còpia d'informació.
# Conclusió
Quan s'ha de modificar repetidament una cadena (afegir, inserir, substituir), utilitzarem StringBuilder per què al ser mutable les modificacions són més eficients.