CREATE TABLE [dbo].[Frais]
(
	[nom] NVARCHAR(50) NOT NULL, 
    [prenom] NVARCHAR(50) NOT NULL, 
    [data] NVARCHAR(50) NOT NULL, 
    [kilometre] INT NOT NULL, 
    [ville] NVARCHAR(50) NOT NULL, 
    [fraisrestaurant] DECIMAL(18, 2) NOT NULL, 
    [codepostal] NVARCHAR(50) NOT NULL, 
    [courriel] NVARCHAR(50) NOT NULL
)


CREATE TABLE [dbo].[Ville]
(
	[nom] NVARCHAR(50) NOT NULL PRIMARY KEY
)
-----------------------------------------------------------------------------------------

