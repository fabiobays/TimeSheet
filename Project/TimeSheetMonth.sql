CREATE TABLE [dbo].[TimeSheetMonth]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [employeeId] INT NOT NULL, 
    [month] INT NOT NULL, 
    [year] INT NOT NULL, 
    [totalHours] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_TimeSheetMonth_Employee] FOREIGN KEY (employeeId) REFERENCES [Employee](id)
)
