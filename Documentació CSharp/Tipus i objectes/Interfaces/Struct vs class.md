# Struct vs class
La funcionalitat que ens aporten un struct i un class és la mateixa. Per tant, cal pendre una decisió de quina de les dues opcions escollir per a cada situació. 
## Característiques
✔️ Struct utilitza un sistema de memòria més eficient per a gestionar la informació, però de mida més limitada (ulimit -a # valor associat a stack size ) que les classes. 
✔️ Struct, quan s'utilitza per paràmetre, el seu pas per defecte és per valor. El pas per defecte d'un objecte és per referència. Podem modificar aquest comportament amb in, ref o out.
❌ No es recomana utilitzar struct si la mida de la informació que s'hi vol emmagatzemar és superior a 16 bytes.
❌ No es recomana utilitzar struct que continguin propietats associades a altres classes: pas de paràmetres diferent pot portar a un funcionament del programa inesperat i de difícil depuració.
## Quadre resum
# 📌 Quan utilitzar `struct` o `class` en C#

| **Cas**             | **Usa `struct`**                                      | **Usa `class`**                                       |
|---------------------|------------------------------------------------------|------------------------------------------------------|
| **Mida total**      | ≤ 16 bytes                                           | > 16 bytes                                           |
| **Tipus de dades**  | Només tipus valor (`int`, `double`, etc.)            | Conté tipus referència (`string`, `object`)         |
| **Còpia per valor o referència?** | Necessites copiar dades sovint i evitar referències compartides | Necessites passar-lo per referència per compartir estat |
| **Herència**        | No necessites herència ni polimorfisme                | Necessites derivació (`class BasePais : Pais`)      |
| **Canvis futurs**   | L'estructura no canviarà molt                        | Pot necessitar nous camps i mètodes més endavant    |
| **Col·leccions**    | Es crea en grans quantitats i vols optimitzar memòria (evitant el `heap`) | Sovint es treballarà amb llistes o estructures de dades grans |

