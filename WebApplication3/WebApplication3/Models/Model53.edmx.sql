
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/21/2019 18:17:41
-- Generated from EDMX file: C:\Users\Lenovo Rose\source\repos\Samdark2000\PracticaProgramacion3\WebApplication3\WebApplication3\Models\Model53.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Agenda3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Agenda2Set]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agenda2Set];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Agenda2Set'
CREATE TABLE [dbo].[Agenda2Set] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Evento] nvarchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Hora] time  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Agenda2Set'
ALTER TABLE [dbo].[Agenda2Set]
ADD CONSTRAINT [PK_Agenda2Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------