CREATE PROCEDURE [dbo].[spExam_Create]
	@CreatedBy int = 0,
	@Description VARCHAR(MAX),
	@Name VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Exam] ([CreatedBy], [Description], [Name]) VALUES (@CreatedBy, @Description, @Name)
END
