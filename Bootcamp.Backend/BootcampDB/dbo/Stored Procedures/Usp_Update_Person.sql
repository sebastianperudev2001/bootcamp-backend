CREATE PROCEDURE [dbo].[Usp_Update_Person]
 (@Id INT,
  @Name VARCHAR(50),
  @Lastname VARCHAR(50),
  @DocumentNumber VARCHAR(20),
  @DocumentTypeId INT,
  @Birthday DATETIME)
 AS
 BEGIN

	UPDATE [dbo].[Person] SET
		Name = @Name,
		Lastname = @Lastname,
		DocumentNumber = @DocumentNumber,
		DocumentTypeId = @DocumentTypeId,
		Birthday = @Birthday
	WHERE Id = @Id

 END