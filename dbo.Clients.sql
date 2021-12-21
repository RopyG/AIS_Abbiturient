CREATE TABLE [dbo].[Abbiturients] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [Login]           NCHAR (20) NULL,
    [FirstName]       NCHAR (20) NULL,
    [LastName]        NCHAR (20) NULL,
    [TrainingProgram] NCHAR (20) NULL,
    [FormOfTraining]  NCHAR (20) NULL,
    [Base]            NCHAR (20) NULL,
    [Direction]       NCHAR (20) NULL,
    [PhoneNumber]     NCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

