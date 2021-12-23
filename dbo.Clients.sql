CREATE TABLE [dbo].[Abiturient] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (MAX) NULL,
    [LastName]        NVARCHAR (MAX) NULL,
    [TrainingProgram] NVARCHAR (MAX) NULL,
    [FormOfTraining]  NVARCHAR (MAX) NULL,
    [Base]            NVARCHAR (MAX) NULL,
    [Direction]       NVARCHAR (MAX) NULL,
    [PhoneNumber]     NVARCHAR (MAX) NULL,
    [Scores]          INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

