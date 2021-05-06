CREATE PROCEDURE [dbo].[spExam_GetUserExams]
	@CreatedById int = 0
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].[Exam]
	WHERE CreatedBy = @CreatedById
END