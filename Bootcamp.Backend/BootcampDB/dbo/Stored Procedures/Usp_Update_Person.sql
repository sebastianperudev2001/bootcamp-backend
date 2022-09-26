CREATE PROCEDURE [dbo].[Usp_Update_Person]
@Id int, 
@Name VARCHAR(50),
@Lastname VARCHAR(50),
@DocumentTypeId INT,
@DocumentNumber VARCHAR(50)
AS
BEGIN
	UPDATE [dbo].[Person] SET
	Name = @Name,
	Lastname = @Lastname,
	DocumentTypeId = @DocumentTypeId,
	DocumentNumber = @DocumentNumber
	WHERE id = @Id
END