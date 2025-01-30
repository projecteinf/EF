# Non Nullable Reference Types

## Motivació dels Non-nullable Reference Types

   - Prevenció d'errors en temps de compilació:

        El compilador pot detectar quan una referència pot ser null i quan no. Això permet que el compilador et notifiqui de possibles errors de nul·litat abans que el codi s'executi, reduint així la probabilitat de NullReferenceException.

   - Millora de la claritat del codi:

        Aquesta característica obliga als desenvolupadors a ser més explícits sobre si una referència pot ser null o no. Això fa que el codi sigui més fàcil d'entendre i mantenir, ja que les intencions del desenvolupador són més clares.

        **Exemple**: si una variable es declara com string?, qualsevol que llegeixi el codi sap immediatament que aquesta variable pot ser null. Si es declara com string, es presumeix que no serà null.
