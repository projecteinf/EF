# Crear contenidor nou
```bash
# Ubicat a la carpeta EF
    sudo docker-compose -f 'App Examples/Console App/20.DB/Docker/docker-compose.yaml' up -d --build 'mssql'
```
# Arrancar el contenidor
```bash
    sudo docker ps # per veure contenidors arrancats
    sudo docker ps -a # per veure tots els contenidors
    sudo docker start sqlserver
```
# Accés a base de dades
- User: SA
- Password: Patata1234
