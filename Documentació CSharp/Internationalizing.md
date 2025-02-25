# Internationalizing
Al món els formats dels números, de les dates... són diferents entre diferents regions. A més d'aquestes diferències, cada regió té un idioma que pot ser propi. Si volem que les nostres aplicacions es puguin utilitzar de manera global hem de tenir en compte aquests factors.  
"Internationalizing" consisteix en determinar la regió de l'usuari i utilitzar les característiques de la seva regió (idioma, formats, moneda, ...) en el programa.  
La internacionalització està formada per dues parts **
La combinació del llenguatge i de les característiques regionals és el que anomenem **culture**.  
[Codis de cultura suportats en C#](https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/supported-culture-codes)
# Obtenir la cultura definida per l'usuari
Disposem de la classe CultureInfo per a determinar la cultura de l'equip que està utilitzant l'usuari. Dins d'aquesta classe disposem de 2 mètodes: 
- CurrentCulture 
- CurrentUICulture 
## CurrentCulture 
Cultura per a format de dades  
## CurrentUICulture 
Cultura per a l'idioma de la UI  
