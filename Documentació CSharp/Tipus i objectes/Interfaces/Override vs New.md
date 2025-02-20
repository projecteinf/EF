# Introducció
En la herència d'una classe, podem definir mètode amb el mateix nom i signatura entre la classe pare i fill. Per fer-ho disposem de dues opcions: override i new.  
# Característiques d'override i new

| **Característica**                            | `override` | `new` |
|-----------------------------------------------|-----------|-------|
| Requereix `virtual` a la classe base         | ✅ Sí     | ❌ No  |
| Substitueix el mètode base?                   | ✅ Sí     | ❌ No, només l’oculta |
| Permet polimorfisme?                          | ✅ Sí     | ❌ No  |
| Es crida des d’una referència de la base?     | ✅ Executa el de la classe derivada | ❌ Executa el de la base |

