CREATE TABLE [dbo].[Table]
(
	[Role] NVARCHAR(50) NOT NULL , 
    [MenuList] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([MenuList], [Role])
)
