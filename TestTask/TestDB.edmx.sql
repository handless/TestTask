
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/03/2013 17:12:40
-- Generated from EDMX file: C:\Users\handless\Documents\GitHub\TestTask\TestTask\TestDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestTableDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'JobsSet'
CREATE TABLE [dbo].[JobsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [JobsName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmployeesSet'
CREATE TABLE [dbo].[EmployeesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Salary] float  NOT NULL,
    [JobsId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'JobsSet'
ALTER TABLE [dbo].[JobsSet]
ADD CONSTRAINT [PK_JobsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeesSet'
ALTER TABLE [dbo].[EmployeesSet]
ADD CONSTRAINT [PK_EmployeesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [JobsId] in table 'EmployeesSet'
ALTER TABLE [dbo].[EmployeesSet]
ADD CONSTRAINT [FK_JobsEmployees]
    FOREIGN KEY ([JobsId])
    REFERENCES [dbo].[JobsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobsEmployees'
CREATE INDEX [IX_FK_JobsEmployees]
ON [dbo].[EmployeesSet]
    ([JobsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------