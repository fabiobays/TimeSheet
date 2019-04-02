CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [employeeId] INT NOT NULL, 
    [timesheetMonthId] INT NOT NULL, 
    [hourlyRate] DECIMAL(18, 2) NOT NULL, 
    [gross] DECIMAL(18, 2) NOT NULL, 
    [cpp] DECIMAL(18, 2) NOT NULL, 
    [ei] DECIMAL(18, 2) NOT NULL, 
    [net] DECIMAL(18, 2) NOT NULL, 
    [tax] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_Payment_ToEmployee] FOREIGN KEY (employeeId) REFERENCES Employee(id), 
    CONSTRAINT [FK_Payment_ToTimeSheetMonth] FOREIGN KEY (timesheetMonthId) REFERENCES TimeSheetMonth(id) 
)
