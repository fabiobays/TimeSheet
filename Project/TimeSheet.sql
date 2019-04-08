CREATE TABLE [dbo].[TimeSheet]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [employeeId] INT NOT NULL, 
    [timesheetMonthId] INT NOT NULL, 
    [day] INT NOT NULL, 
    [hoursWorked] DECIMAL(18, 2) NULL DEFAULT 0, 
    CONSTRAINT [FK_TimeSheet_Employee] FOREIGN KEY (employeeId) REFERENCES [Employee](id), 
    CONSTRAINT [FK_TimeSheet_TiomeSheetMonth] FOREIGN KEY (timesheetMonthId) REFERENCES TimeSheetMonth(id) 
)
