CREATE TABLE [dbo].[AllocateClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[StartTime] [varchar](20) NULL,
	[EndTime] [varchar](20) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_AllocateClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssignCourseToTeacher]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssignCourseToTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AssignCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Description] [varchar](500) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Day]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [varchar](10) NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollStudent]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EnrollStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[Date] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_Enroll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetter] [varchar](50) NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Result]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[GradeId] [int] NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNo] [varchar](50) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[ContactNo] [varchar](50) NULL,
	[Date] [varchar](50) NOT NULL,
	[Address] [varchar](500) NULL,
	[DepartmentId] [int] NOT NULL,
	[Year] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 24/09/2018 21:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[ContactNo] [varchar](50) NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditTaken] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] ON 

INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (51, 2, 1, 1, 1, N'10:00 AM', N'12:00 PM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (52, 2, 2, 1, 1, N'8:00 AM', N'9:00 AM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (53, 2, 1002, 1, 1, N'9:30 PM', N'10:30 PM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (54, 2, 2, 2, 1, N'11:00 AM', N'1:00 PM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (55, 2, 1002, 1, 1, N'9:00 AM', N'10:00 AM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (56, 2, 1005, 1, 1, N'2:00 PM', N'4:00 PM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (57, 2, 1003, 1, 1, N'1:00 PM', N'2:00 PM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (58, 2, 1004, 1, 1, N'12:00 PM', N'1:00 PM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (59, 2, 1011, 1, 2, N'10:30 AM', N'11:30 AM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (60, 2, 1010, 1, 2, N'11:30 AM', N'12:30 PM', N'ALLOCATED')
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [StartTime], [EndTime], [Type]) VALUES (61, 2, 1009, 1, 2, N'1:30 PM', N'4:30 PM', N'ALLOCATED')
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] OFF
SET IDENTITY_INSERT [dbo].[AssignCourseToTeacher] ON 

INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (1, 1, 1, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (2, 2, 1002, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (3, 1004, 2, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (4, 1004, 1004, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (5, 1004, 1003, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (6, 2, 1005, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (7, 3, 1006, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (8, 1004, 1007, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (9, 1003, 1009, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (10, 1003, 1010, N'UNASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (12, 2, 1, N'ASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (13, 1005, 1011, N'ASSIGNED')
INSERT [dbo].[AssignCourseToTeacher] ([Id], [TeacherId], [CourseId], [Type]) VALUES (14, 2, 1010, N'ASSIGNED')
SET IDENTITY_INSERT [dbo].[AssignCourseToTeacher] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1, N'CSE100', N'Introduction to Computer Systems', CAST(1.50 AS Decimal(18, 2)), N'About Computer Fundamentals', 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (2, N'MAT100', N'Mathematics I', CAST(1.25 AS Decimal(18, 2)), N'Basic Mathematics', 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1002, N'CSE102', N'Basic Programming', CAST(2.00 AS Decimal(18, 2)), N'No description', 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1003, N'MAT501', N'Mathematics II', CAST(2.00 AS Decimal(18, 2)), N'No description', 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1004, N'ENG101', N'English I', CAST(2.00 AS Decimal(18, 2)), N'No description', 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1005, N'CSE109', N'Database Management Systems', CAST(3.00 AS Decimal(18, 2)), N'About database management', 2, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1006, N'PHY-101', N'Physics I', CAST(2.50 AS Decimal(18, 2)), N'About physics basic', 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1007, N'ACC-101', N'Basic Accounting', CAST(2.50 AS Decimal(18, 2)), N'About basic accounting', 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1008, N'EEE101', N'Basic Electronics', CAST(2.00 AS Decimal(18, 2)), N'About Basic electronics', 3, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1009, N'CSE110', N'Neural Network', CAST(1.50 AS Decimal(18, 2)), N'About Neural network', 2, 7)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1010, N'CSE505', N'Computer Network', CAST(2.00 AS Decimal(18, 2)), N'About computer network', 2, 6)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1011, N'CSE506', N'Data Communication', CAST(1.50 AS Decimal(18, 2)), N'About Computer Data Communication', 2, 6)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([Id], [DayName]) VALUES (3, N'Mon')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (1, N'Sat')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (2, N'Sun')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (6, N'Thus')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (4, N'Tue')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (5, N'Wed')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1, N'BBA', N'Business Adminstration')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2, N'CSE', N'Computer Science & Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (3, N'EEE', N'Electrical and Electronics Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (4, N'HIS', N'History')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (5, N'ETE', N'Eletrical & Telecommunication Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (6, N'MAT', N'Mathematics')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (7, N'PHY', N'Physics')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1004, N'ECO', N'Economics')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (2, N'Assistant Professior')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (1, N'Department Head')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (3, N'Lecturer')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollStudent] ON 

INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (1, 1, 1, N'17/09/2018', N'UNENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (2, 2, 1002, N'17/09/2018', N'UNENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (3, 4, 1, N'17/09/2018', N'UNENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (4, 4, 2, N'17/09/2018', N'UNENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (5, 3, 1002, N'17/09/2018', N'UNENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (6, 4, 1003, N'18/09/2018', N'UNENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (7, 4, 1006, N'19/09/2018', N'UNENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (8, 1, 1, N'19/09/2018', N'ENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (9, 1, 2, N'19/09/2018', N'ENROLLED')
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [Date], [Type]) VALUES (10, 1, 1011, N'22/09/2018', N'ENROLLED')
SET IDENTITY_INSERT [dbo].[EnrollStudent] OFF
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (5, N'B')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (6, N'B-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (4, N'B+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (8, N'C')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (9, N'C-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (7, N'C+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (11, N'D')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (12, N'D-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (10, N'D+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grade] OFF
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Type]) VALUES (1, 1, 1, 1, N'UNASSIGNED')
INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Type]) VALUES (2, 2, 1002, 1, N'UNASSIGNED')
INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Type]) VALUES (3, 3, 1002, 4, N'UNASSIGNED')
INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Type]) VALUES (4, 4, 1, 5, N'UNASSIGNED')
INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Type]) VALUES (5, 4, 2, 2, N'UNASSIGNED')
INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Type]) VALUES (6, 1, 1, 1, N'ASSIGNED')
INSERT [dbo].[Result] ([Id], [StudentId], [CourseId], [GradeId], [Type]) VALUES (7, 1, 2, 2, N'ASSIGNED')
SET IDENTITY_INSERT [dbo].[Result] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (1, N'501')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (2, N'502')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (3, N'503')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (4, N'504')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (5, N'505')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (6, N'506')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (7, N'507')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (8, N'508')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (9, N'CL-2')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (10, N'CL-3')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (11, N'CL-4')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (12, N'CL-5')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (13, N'CL-6')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (1, N'CSE-2018-001', N'Irfat Mahmood', N'mahmoodirfat775@gmail.com', N'01558014456', N'14/09/2018', N'250/A  Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (2, N'CSE-2018-002', N'Sara Azmin', N'saraazmin@gmail.com', N'01844715548', N'14/09/2018', N'250/B Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (3, N'CSE-2018-003', N'Tawfique Hossain', N'tawfiquehossain@gmail.com', N'01233668874', N'14/09/2018', N'250/C Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (4, N'CSE-2018-004', N'Sukesh Dutta', N'sukeshdutta@gmail.com', N'01991154745', N'14/09/2018', N'250/D Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (5, N'EEE-2018-001', N'Ruhul Kuddus', N'ruhulkuddus@gmail.com', N'017988988998', N'14/09/2018', N'250/F Ctg', 3, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (6, N'CSE-2017-001', N'Ruhul Kuddus Chisty', N'ruhulkudduschisty@gmail.com', N'017988988998', N'09/08/2017', N'250/N Ctg', 2, N'2017')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (7, N'CSE-2017-002', N'Ruhul Kuddus Nayeem', N'ruhulkuddusnayeem@gmail.com', N'017988988998', N'28/10/2017', N'250/G Ctg', 2, N'2017')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (8, N'CSE-2018-005', N'Suon Chy', N'suon@gmail.com', N'017988988998', N'14/09/2018', N'250/G Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (9, N'CSE-2017-003', N'Karim', N'karim@gmail.com', N'017988988998', N'20/10/2017', N'250/G Ctg', 2, N'2017')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (10, N'CSE-2018-006', N'Kuddus Nayeem', N'nayeem@gmail.com', N'017988988998', N'14/09/2018', N'250/G Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (12, N'EEE-2018-002', N'Md Rizvi', N'a@gmai.com', N'0155877463', N'22/09/2018', N'255/B Ctg', 3, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (13, N'EEE-2018-003', N'Mahamudul', N'mahmud@gmail.com', N'0155874666', N'22/09/2018', N'284/D Ctg', 3, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (14, N'CSE-2018-007', N'Siam', N'siam@gmail.com', N'01558477669', N'22/09/2018', N'56/A Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (15, N'CSE-2018-008', N'Saiful Islam', N'saiful@gmail.com', N'0188447965', N'22/09/2018', N'255/A Ctg', 2, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (16, N'EEE-2017-001', N'Zahir', N'zahir@gmail.com', N'0155877446', N'11/10/2017', N'209/D Ctg', 3, N'2017')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (17, N'EEE-2018-004', N'Jahin', N'jahin@yahoo.com', N'01887744559', N'22/09/2018', N'9/9A Ctg', 3, N'2018')
INSERT [dbo].[Student] ([Id], [RegNo], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [Year]) VALUES (18, N'EEE-2017-002', N'Robiul', N'robiul@gmail.com', N'0112366847', N'22/09/2017', N'205/L Ctg', 3, N'2017')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken]) VALUES (1, N'Tawfique Sayeed', N'205/a Ctg', N'tawfique@gmail.com', N'01844715548', 1, 2, CAST(19.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken]) VALUES (2, N'Mahmood', N'204/b Ctg', N'mahmood@gmail.com', N'018447996697', 3, 2, CAST(25.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken]) VALUES (3, N'Nayeem', N'25/C Ctg', N'nayeem@gmail.com', N'01558014456', 2, 2, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken]) VALUES (1002, N'Rahim', N'25/A Ctg', N'rahim@gmail.com', N'No ContactNo', 3, 2, CAST(29.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken]) VALUES (1003, N'Kuddus', N'65/A Cth', N'kuddus@gmail.com', N'No ContactNo', 3, 2, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken]) VALUES (1004, N'Jumman', N'205/C Ctg', N'jumman@gmail.com', N'0184477996', 3, 2, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditTaken]) VALUES (1005, N'Ahmed', N'205/A Ctg', N'ahmed@yahoo.com', N'01884476695', 3, 2, CAST(15.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [IX_Course] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course_1]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [IX_Course_1] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Day]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Day] ADD  CONSTRAINT [IX_Day] UNIQUE NONCLUSTERED 
(
	[DayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_Department] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_1]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_Department_1] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Designation]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Designation] ADD  CONSTRAINT [IX_Designation] UNIQUE NONCLUSTERED 
(
	[DesignationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Grade]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Grade] ADD  CONSTRAINT [IX_Grade] UNIQUE NONCLUSTERED 
(
	[GradeLetter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Room]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [IX_Room] UNIQUE NONCLUSTERED 
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Semester]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Semester] ADD  CONSTRAINT [IX_Semester] UNIQUE NONCLUSTERED 
(
	[SemesterName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [IX_Student] UNIQUE NONCLUSTERED 
(
	[RegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student_1]    Script Date: 24/09/2018 21:47:47 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [IX_Student_1] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Course]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Day] FOREIGN KEY([DayId])
REFERENCES [dbo].[Day] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Day]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Department]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Room]
GO
ALTER TABLE [dbo].[AssignCourseToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_AssignCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AssignCourseToTeacher] CHECK CONSTRAINT [FK_AssignCourse_Course]
GO
ALTER TABLE [dbo].[AssignCourseToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_AssignCourse_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[AssignCourseToTeacher] CHECK CONSTRAINT [FK_AssignCourse_Teacher]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
ALTER TABLE [dbo].[EnrollStudent]  WITH CHECK ADD  CONSTRAINT [FK_Enroll_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[EnrollStudent] CHECK CONSTRAINT [FK_Enroll_Course]
GO
ALTER TABLE [dbo].[EnrollStudent]  WITH CHECK ADD  CONSTRAINT [FK_Enroll_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[EnrollStudent] CHECK CONSTRAINT [FK_Enroll_Student]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Course]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Grade] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grade] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Grade]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
USE [master]
GO
ALTER DATABASE [UniversityManagementSystemDB] SET  READ_WRITE 
GO
