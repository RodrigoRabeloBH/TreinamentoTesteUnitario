
CREATE DATABASE [Totvs.Locadora] 
GO

USE [Totvs.Locadora] 
GO

CREATE TABLE [Filme] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] varchar(80) NOT NULL,
    [DataLancamento] datetime2 NOT NULL,
    [Genero] varchar(40) NOT NULL,
    [Preco] float NOT NULL,
    CONSTRAINT [PK_Filme] PRIMARY KEY ([Id])
);
GO

