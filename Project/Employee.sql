CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [firstName] NVARCHAR(120) NULL, 
    [lastName] NVARCHAR(120) NULL, 
    [address] NVARCHAR(120) NULL, 
    [phone] NVARCHAR(20) NULL, 
    [email] NVARCHAR(50) NULL, 
    [hourlyRate] DECIMAL(18, 2) NULL
)
