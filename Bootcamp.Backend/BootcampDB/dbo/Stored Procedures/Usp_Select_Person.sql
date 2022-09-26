CREATE PROCEDURE [dbo].[Usp_Select_Person]
AS 
	BEGIN
		SELECT
			p.Id,
			p.Name,
			p.Lastname,
			p. DocumentNumber, 
			d.Shortname
		FROM [dbo].[Person] p 
		JOIN [dbo].[DocumentType] d
		ON p.DocumentTypeId = d.Id
END