USE [StudentsDB]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 4/25/2023 2:27:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](200) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/25/2023 2:27:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[EnrollmentYear] [int] NULL,
	[StatusId] [bigint] NULL,
	[StudentNumber] [nchar](20) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 4/25/2023 2:27:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [bigint] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentStatus]    Script Date: 4/25/2023 2:27:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentStatus](
	[StatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[StatusName] [nchar](150) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([CourseId], [CourseName]) VALUES (1, N'Java Development')
GO
INSERT [dbo].[Course] ([CourseId], [CourseName]) VALUES (2, N'Microsoft Development')
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [EnrollmentYear], [StatusId], [StudentNumber]) VALUES (1, N'John', N'Doe', 2012, 2, N'36/12            ')
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [EnrollmentYear], [StatusId], [StudentNumber]) VALUES (3, N'Mike', N'Shinoda', 2010, 1, N'22/10               ')
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [EnrollmentYear], [StatusId], [StudentNumber]) VALUES (4, N'Mary', N'Jane', 2013, 2, N'24/13               ')
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentCourse] ON 
GO
INSERT [dbo].[StudentCourse] ([Id], [CourseId], [StudentId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[StudentCourse] ([Id], [CourseId], [StudentId]) VALUES (2, 1, 3)
GO
INSERT [dbo].[StudentCourse] ([Id], [CourseId], [StudentId]) VALUES (3, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[StudentCourse] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentStatus] ON 
GO
INSERT [dbo].[StudentStatus] ([StatusID], [StatusName]) VALUES (1, N'Redovan                                                                                                                                               ')
GO
INSERT [dbo].[StudentStatus] ([StatusID], [StatusName]) VALUES (2, N'Vanredan                                                                                                                                              ')
GO
SET IDENTITY_INSERT [dbo].[StudentStatus] OFF
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_StudentStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[StudentStatus] ([StatusID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_StudentStatus]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
