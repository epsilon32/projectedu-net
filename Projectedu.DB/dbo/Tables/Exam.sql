CREATE TABLE [dbo].[Exam]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [Description] NVARCHAR(MAX) NULL, 
    [Name] NVARCHAR(100) NULL
)
