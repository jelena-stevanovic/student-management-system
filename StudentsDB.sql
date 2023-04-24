USE [StudentsDB]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/24/2023 2:21:46 AM ******/
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
/****** Object:  Table [dbo].[StudentStatus]    Script Date: 4/24/2023 2:21:46 AM ******/
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
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [EnrollmentYear], [StatusId], [StudentNumber]) VALUES (1, N'John', N'Doe', 2012, 2, N'12/36               ')
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [EnrollmentYear], [StatusId], [StudentNumber]) VALUES (3, N'Mike', N'Shinoda', 1993, 1, N'22/38               ')
GO
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [EnrollmentYear], [StatusId], [StudentNumber]) VALUES (4, N'Mary', N'Jane', 1234, 2, N'11/24               ')
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
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
