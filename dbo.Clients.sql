CREATE TABLE [dbo].[Clients] (
    [Id]   INT        IDENTITY (1, 1) NOT NULL,
    [FirstName] NCHAR (20) NOT NULL,
    [LastName] NCHAR(20) NULL, 
    [TrainingProgram] NCHAR(30) NOT NULL, 
    [FormOfTraining] NCHAR(30) NOT NULL, 
    [Base] NCHAR(16) NOT NULL, 
    [Direction] NCHAR(30) NOT NULL, 
    [PhoneNumber] NCHAR(20) NULL, 
    [Login] NCHAR(10) NULL, 
    [Password] NCHAR(16) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

