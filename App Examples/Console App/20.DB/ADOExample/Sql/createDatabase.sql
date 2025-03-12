USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'dbdemo')
    CREATE DATABASE dbdemo;
GO

USE dbDemo;
GO

-- sys.tables conté les taules de la base de dades activa
-- La mida de SaltPassword es correspon a la constant SALT_SIZE de la classe estàtica Password
-- La mida de HashPassword es correspon a la constant PASSWORD_HASH_SIZE de la classe estàtica Password
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        Uuid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY, 
        Name VARCHAR(50) NOT NULL,
        EMail VARCHAR(255),
        DateOfBirth DATE,
        SaltPassword VARBINARY(16) NOT NULL,
        HashPassword VARBINARY(32) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Items')
BEGIN
    CREATE TABLE Items (
        Uuid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY, 
        Name VARCHAR(10) NOT NULL,
        Price Decimal(7,2) NOT NULL,    -- entre 0 i 99999.99
        UserOwner UNIQUEIDENTIFIER NOT NULL,
        CONSTRAINT FK_USEROBJECTS 
            FOREIGN KEY (UserOwner) REFERENCES Users(Uuid)  -- UPDATE AND DELETE NOT ALLOWED
                ON UPDATE NO ACTION
                ON DELETE NO ACTION
    );
END
GO