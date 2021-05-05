CREATE PROCEDURE [dbo].[spUserPassLookup]
	@UserName NVARCHAR(50),
	@Password NVARCHAR(50) -- TODO, this should be a hash (right now its not used)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].[User]
	WHERE UserName = @UserName
		-- TODO password checking
END
