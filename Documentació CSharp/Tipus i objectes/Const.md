# Const vs read-only

Una constant és un valor (string literal, valor numèric o booleà) que no pot canviar en el temps. El compilador, en temps de compilació, substitueix el camp que associem a la constant pel valor literal de la constant. Si hem de canviar el valor de la constant, haurem de tornar a compilar el codi. 

És problemàtic si la constant està definida en una llibreria. La llibreria i tots els projectes que l'utilitzen emmagatzemaran el valor literal de la constant. Al modificar aquesta, caldrà compilar la llibreria i tots els programes associats.

Els camps de tipus read-only es defineixen en temps d'execució. Per tant, cada vegada que s'executa el programa se'n determina el seu valor. En aquest cas, només cal compilar la llibreria.


