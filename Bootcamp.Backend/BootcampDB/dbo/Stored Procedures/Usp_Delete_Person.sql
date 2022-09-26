CREATE PROCEDURE [dbo].[Usp_Delete_Person]
@Id int
AS
BEGIN
	DELETE FROM [dbo].[Person] 
	WHERE id = @Id
END