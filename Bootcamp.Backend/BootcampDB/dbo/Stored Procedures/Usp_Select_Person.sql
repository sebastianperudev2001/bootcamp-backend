CREATE PROCEDURE [dbo].[Usp_Select_Person]
 AS
 BEGIN

	SELECT 
		P.Id,
		P.Name,
		P.Lastname,
		P.DocumentNumber,
		DT.ShortName AS DocumentType,
		Birthday
	FROM [dbo].[Person] P
	INNER JOIN [dbo].[DocumentType] DT ON DT.Id = P.DocumentTypeId

 END
