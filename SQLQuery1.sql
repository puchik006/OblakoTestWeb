﻿CREATE DATABASE [TestDb]

CONTAINMENT = NONE

ON PRIMARY

( NAME = N'TestDb',

FILENAME = N'D:\BuVisualStudio\OblakoTestWeb\TestDb.mdf' ,

SIZE = 8192KB ,

MAXSIZE = UNLIMITED,

FILEGROWTH = 65536KB )

LOG ON

( NAME = N'TestDb _log',

FILENAME = N'D:\BuVisualStudio\OblakoTestWeb\TestDb_log.ldf' ,

SIZE = 8192KB ,

MAXSIZE = 2048GB ,

FILEGROWTH = 65536KB )

GO

USE [TestDb]

GO

CREATE TABLE [dbo].[Product] (

[ID] [uniqueidentifier] NOT NULL,

[Name] [nvarchar](255) NOT NULL,

[Description] [nvarchar](max) NULL,

CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ID])

)

ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [Product_Name_IDX] ON [dbo].[Product]

(Name)

WITH (

PAD_INDEX = OFF,

DROP_EXISTING = OFF,

STATISTICS_NORECOMPUTE = OFF,

SORT_IN_TEMPDB = OFF,

ONLINE = OFF,

ALLOW_ROW_LOCKS = ON,

ALLOW_PAGE_LOCKS = ON)

ON [PRIMARY]

GO