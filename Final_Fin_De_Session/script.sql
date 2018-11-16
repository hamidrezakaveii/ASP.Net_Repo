USE [Test_Hami]
GO
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
