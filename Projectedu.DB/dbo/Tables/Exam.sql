CREATE TABLE [dbo].[Exam]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [Description] NVARCHAR(MAX) NULL
)
