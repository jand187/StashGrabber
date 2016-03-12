CREATE TABLE [dbo].[ItemsRaw] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Name]        NCHAR (100)  NULL,
    [ExternalId ] NCHAR (100)  NOT NULL,
    [ItemLevel]   NCHAR (10)   NULL,
    [Icon]        NCHAR (1024) NULL,
    [TypeLine]    NCHAR (100)  NULL,
    [Corrupted]   BIT          NULL,
    [Identified]  BIT          NULL,
    [Note]        NCHAR (100)  NULL,
    [InventoryId] NCHAR (20)   NULL,
    [LastUpdated] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([ExternalId ] ASC)
);

