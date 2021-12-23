CREATE TABLE [dbo].[Accounts] (
    [Id]       INT       IDENTITY (1, 1) NOT NULL,
    [Login]    NCHAR(50) NULL,
    [Password] VARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

