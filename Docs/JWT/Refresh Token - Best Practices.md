# Consideracions refresh token
- ✅ Generació segura: Ha de ser una cadena aleatòria llarga i segura (mínim 32 bytes, generada amb un CSPRNG).
- ✅ Emmagatzematge segur: Guardar només un hash del refresh token a la base de dades (com es fa amb contrasenyes).
- ✅ Associació a l’usuari: Relacionar-lo amb un identificador d’usuari i una data d’expiració.
- ✅ Lligar-lo a un dispositiu o IP (opcional): Es pot desar informació del client per detectar usos sospitosos.
- ✅ Ús únic (optional, però recomanable): Quan un refresh token s’utilitza per obtenir un nou access token, s’hauria d’invalidar i generar-ne un de nou.