CREATE PROCEDURE [dbo].[spUserLookup]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].[User]
	WHERE Id = @id
END
