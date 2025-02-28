USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'demodb')
    CREATE DATABASE demodb;
GO

USE demodb;
GO

-- sys.tables conté les taules de la base de dades activa
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        Uuid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY, 
        Name VARCHAR(50) NOT NULL,
        EMail VARCHAR(255),
        DateOfBirth DATE,
        saltPassword VARBINARY(16) NOT NULL,
        hashPassword VARBINARY(32) NOT NULL
    );
END
GO
