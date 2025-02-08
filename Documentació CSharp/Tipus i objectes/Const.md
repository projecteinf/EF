# Const vs read-only

Una constant és un valor (string literal, valor numèric o booleà) que no pot canviar en el temps. El compilador, en temps de compilació, substitueix el camp que associem a la constant pel valor literal de la constant. Si hem de canviar el valor de la constant, haurem de tornar a compilar el codi. Pot ser problemàtic, per exemple, si la constant està definida en una llibreria cal compilar la llibreria i el programa!

**Good practice**

Utilitzar els camps read-only

