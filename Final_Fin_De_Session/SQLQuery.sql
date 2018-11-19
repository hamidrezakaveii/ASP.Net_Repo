
/****** Object:  Table [dbo].[LMEmployees]    Script Date: 2018-11-16 15:31:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LMEmployees](
	[EmpId] [int] NOT NULL,
	[EmpFName] [nvarchar](50) NOT NULL,
	[EmpLName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[ManagerEmpId] [int] NOT NULL,
	[Grade] [nvarchar](20) NOT NULL,
	[Sex] [nvarchar](50) NULL,
	[Tel] [nvarchar](30) NULL,
	[SickLeaveBalance] [int] NOT NULL,
	[EarnedLeaveBalance] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Pass] [varchar](50) NOT NULL,
 CONSTRAINT [LMEmployees_Emp_ID_PK] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LMLeaveHistory]    Script Date: 2018-11-16 15:31:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LMLeaveHistory](
	[LeaveId] [int] NOT NULL,
	[EmpId] [int] NOT NULL,
	[ApplicationDate] [date] NOT NULL,
	[LeaveStartDate] [date] NOT NULL,
	[LeaveEndDate] [date] NOT NULL,
	[LeaveType] [nvarchar](20) NOT NULL,
	[LeaveDesc] [nvarchar](50) NOT NULL,
	[LeaveState] [nvarchar](20) NOT NULL,
	[StateReason] [nvarchar](50) NOT NULL,
 CONSTRAINT [LMLeaveHistory_Leave_ID_PK] PRIMARY KEY CLUSTERED 
(
	[LeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LMEmployees]  WITH CHECK ADD  CONSTRAINT [LMEmployees_MAN_EMP_ID_FK] FOREIGN KEY([ManagerEmpId])
REFERENCES [dbo].[LMEmployees] ([EmpId])
GO
ALTER TABLE [dbo].[LMEmployees] CHECK CONSTRAINT [LMEmployees_MAN_EMP_ID_FK]
GO
ALTER TABLE [dbo].[LMLeaveHistory]  WITH CHECK ADD  CONSTRAINT [LMLeaveHistory_EMP_ID_FK] FOREIGN KEY([EmpId])
REFERENCES [dbo].[LMEmployees] ([EmpId])
GO
ALTER TABLE [dbo].[LMLeaveHistory] CHECK CONSTRAINT [LMLeaveHistory_EMP_ID_FK]
GO

--DML
 
insert into [dbo].[LMEmployees] values (100,'Steven','King','1980-07-18',100,'Manager','Male','514-5672319',20,	0,'sking@company.com','123@Abc');
insert into [dbo].[LMEmployees] values (101,'John','Diggwood','1981-11-06',100,	'Manager','Male','514-3248956',15,0,'jdigwood@company.com','123@Abc');
insert into [dbo].[LMEmployees] values (102,'Admin','Admin','2000-01-01',101,'Admin','Male','514-88888888',30,0,'admin@company.com','123@Abc');
insert into [dbo].[LMEmployees] values (103,'Alain','Jones','1981-11-06',101,'Employee','Male','514-8086453',15,0,'ajones@company.com','123@Abc');
insert into [dbo].[LMEmployees] values (104,'Alice','Lock','1975-07-18',101,'Employee','Female','514-896352',25,0,'alock@company.com','123@Abc');


insert into [dbo].[LMLeaveHistory] values (1000,101,'2018-11-11','2018-11-12','2018-11-14','Personal','','Requested','');	
insert into [dbo].[LMLeaveHistory] values (1001,101,'2018-12-01','2018-12-25','2018-12-27','Personal','','Requested','');
insert into [dbo].[LMLeaveHistory] values (1002,103,'2018-11-15','2018-11-17','2018-11-19','Sickness','','Requested','');
insert into [dbo].[LMLeaveHistory] values (1004,103,'2018-12-20','2018-12-27','2018-12-30','Personal','','Requested','');
insert into [dbo].[LMLeaveHistory] values (1005,104,'2018-11-14','2018-11-18','2018-11-20','Vacation','','Requested','');
insert into [dbo].[LMLeaveHistory] values (1006,104,'2018-11-01','2018-10-28','2018-10-28','Sickness','','Requested','');		

