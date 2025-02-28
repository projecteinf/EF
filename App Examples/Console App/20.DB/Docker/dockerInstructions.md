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
# Crear base de dades
```bash
# Connectar amb el contenidor
sudo docker exec -it sqlserver  /bin/bash
# Connectar amb intèrpret de comandes de Microsoft SQL Server (Transact-SQL)
/opt/mssql-tools/bin/sqlcmd -USA -PPatata1234 -C
# Utilitzar fitxer sql per a executar comandes
echo -e "use master\nGO\nCREATE DATABASE demodb\nGO\nSELECT name, database_id, create_date FROM sys.databases\nGO" > /tmp/createDatabase.sql
/opt/mssql-tools/bin/sqlcmd -USA -PPatata1234 -C -i /tmp/createDatabase.sql
```
![Instruccions creació base de dades a Microsoft SQL Server i docker](https://github.com/user-attachments/assets/27c87062-0e8d-4381-9a5a-7b7f0ac2850c)
