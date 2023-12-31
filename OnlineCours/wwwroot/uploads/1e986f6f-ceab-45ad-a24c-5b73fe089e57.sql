USE [OnlineCourse]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/31/2023 2:41:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LectureDate] [nvarchar](max) NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[Status] [int] NULL,
	[InstructorSubjectBridgeID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomAppointments]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomAppointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LectureDate] [nvarchar](max) NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[Status] [int] NULL,
	[InstructorSubjectBridgeID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_CustomAppointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructors]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructors](
	[applicationUserID] [nvarchar](450) NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Instructors] PRIMARY KEY CLUSTERED 
(
	[applicationUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstructorSubjects]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructorSubjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[InstructorID] [nvarchar](450) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_InstructorSubjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtherRequests]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[File] [nvarchar](max) NULL,
	[ConsultingHoures] [nvarchar](max) NULL,
	[OtherRequests] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_OtherRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestAppointments]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestAppointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [int] NOT NULL,
	[CustomAppointmentID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_RequestAppointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [nvarchar](max) NOT NULL,
	[NumberOfHouers] [int] NULL,
	[status] [int] NOT NULL,
	[StudentID] [nvarchar](450) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ApplicationUserID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ApplicationUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 12/31/2023 2:41:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Grade] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231127180027_init', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231127183023_init34', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231208114501_MahmoudNour', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231209120849_InstructorController', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231214201919_init22', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231229185056_init', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231230104420_iniiit', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231231124018_iniiiitt', N'7.0.2')
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (34, N'22:30', 1, NULL, 23, 0)
INSERT [dbo].[Appointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (35, N'17:00', 2, NULL, 23, 0)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5deaafc8-e0bc-4b4d-831e-a66e3963c678', N'Instractur', N'INSTRACTUR', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a2cc1565-1953-455f-801f-0a39246b1327', N'Student', N'STUDENT', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a841d3c0-4130-4d15-836e-01dcc985c266', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b9587fd4-91bd-4b6c-b9a0-224f1292a486', N'5deaafc8-e0bc-4b4d-831e-a66e3963c678')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ea082751-997d-4b22-8b5e-7194359e4917', N'5deaafc8-e0bc-4b4d-831e-a66e3963c678')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fbd3fd6a-8af5-4be6-9aa0-803507008c87', N'5deaafc8-e0bc-4b4d-831e-a66e3963c678')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34df12f1-d7fd-4fd4-889c-e00bea79b9a8', N'a2cc1565-1953-455f-801f-0a39246b1327')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2755130b-2868-444e-b407-93ae4b6dfaaf', N'Student', 0, N'Student', N'STUDENT', N'Student@gmail.com', N'STUDENT@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEO8XrV6nCxW3yV21cwGopIf1l7JvcVPcCBk4RF6nsenGhsTR5Rro9RSKWpJXfySVEg==', N'PU3I6JHWFRWBYPOTKUXVMLTGKQ5GVIQX', N'6fed52ce-0ebb-4508-b8ea-484543dfe7f2', N'01064797626', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'34df12f1-d7fd-4fd4-889c-e00bea79b9a8', N'Student1', 0, N'Student1', N'STUDENT1', N'Student@gmail.com', N'STUDENT@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFv2rz1Jwt1yGouFICt8P0PN+jc6dTdW+g0YcoKH/n3z+qkVUCbEdIkDXH9KtIPYKw==', N'65MQCLEGYGC2CX3REMR6CIYOYFKUOUVP', N'39619657-e326-4645-8123-4bff27dc39da', N'01064797626', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'43a4ee4d-d2dd-4945-8565-1792957a1573', N'Manar', 0, N'Manar123', N'MANAR123', N'manarmaher123@gmmail.com', N'MANARMAHER123@GMMAIL.COM', 0, N'AQAAAAIAAYagAAAAEJrQhTWL6DLVSse/ZmXyEyhfNZb9xELIv3DieQSBvtqZtwKzY8Td5va5BpWQbdcP0w==', N'SK264HXFHTWP4HQUD7I67ZESG5TPHAPQ', N'08b5162e-1369-4df1-a6ef-576e37b5e620', N'string', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'695845b7-1945-4086-a8ab-25147a41056f', N'InstructorII', 0, N'InstructorII', N'INSTRUCTORII', N'InstructorI@gmail.com', N'INSTRUCTORI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEA57Me55F0BXVXX+8Xoz0r0ku1GCTMpp9RaL/Q5KdPHv/M2/ivxrKI8dUnUHAorQQA==', N'OW7V6IA6GCNDSDTVT2HSOQLE5XSJJLTB', N'35ccb573-e7f4-4eb2-a91c-26a08ee1b497', N'01064797626', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9e2345c2-bbbe-4536-9f73-19e5e727ba09', N'mena', 0, N'mena123', N'MENA123', N'manarmaher123@gmmail.com', N'MANARMAHER123@GMMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPr46sN+IGXrbHoOH6/QtSXhZy92W67L3jliemQrjyCU8GyyM8AYQTJ1I30fxiCBJw==', N'RWUDPVHI6LAWIUGNQFUJFVH6GJYBDBYE', N'4c73c123-7f32-494c-abd4-531b5a6aae41', N'string', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b9587fd4-91bd-4b6c-b9a0-224f1292a486', N'instructorI', 0, N'instructorI', N'INSTRUCTORI', N'instructorI@gmail.com', N'INSTRUCTORI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEBQBpX75q5DNBDp9AV+qCxVXZK0R9bCq85jrrrwdejVEe0W6J3w3nn6fMQCfumymJA==', N'XNT7LGCBI4RO2JKSIOGZVJM7EU3JFLNL', N'b3aaec0c-9d6f-4fe2-b2a9-b4c07411c2b2', N'01064797626', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'cd17cb62-d005-490f-8754-45d7a459ae45', N'instructor2', 0, N'instructor2', N'INSTRUCTOR2', N'instructor2@gmail.com', N'INSTRUCTOR2@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEJsiMGq5uJ2LfNldti6smi2wCdFhIkQRicbr7lC6mfMj0YEfIIaky6vP6uy/K8Wzgw==', N'EUJSXIHRWK3ZLEJYXWAVHOOSHWP3LBVD', N'f5560d71-2635-43d5-9f43-30fe17d3b262', N'01064797626', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd682ca81-f18b-41f6-8ff2-5fa40c29f341', N'instructor12', 0, N'instructor1', N'INSTRUCTOR1', N'instructor1@gmail.com', N'INSTRUCTOR1@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEIvHJ67RW/N5gsQkc0sAV9so/5+zeGxNNJWzPaxhiohoEu+bMxsfVH/iAdA92aZmog==', N'5SP7BEAQQHKFUBOUZ5Z6SC6F26HUG6TC', N'0a6c4d93-5b69-4e20-bf06-1f7dc7c629cd', N'01064797626', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ea082751-997d-4b22-8b5e-7194359e4917', N'instructor1', 0, N'instructor', N'INSTRUCTOR', N'instructor@gmail.com', N'INSTRUCTOR@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGTnCGqmiEUdCJk2OVewYknVZ5Z1+e80W5Q6Cg4ujCXBu7WbP9MrqN6MYKQg+ots7g==', N'VJXTXNFNT5ESN4VUAMFKUN75SVSQY3CF', N'c45947c1-6930-46db-8457-c1488a08f569', N'01064797626', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [IsDeleted], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fbd3fd6a-8af5-4be6-9aa0-803507008c87', N'Instractur123', 0, N'Instractur123', N'INSTRACTUR123', N'Instractur123@gmail.com', N'INSTRACTUR123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEH7bVAxBS2ZEDyCxNUSDaJgZve1khCNeGZsaELGflrUucg3s37fbE4pEowDmn9g/yg==', N'JJQ2FCGIUUTJKQFQZIHTX4WPOPSZNUNW', N'35b5a2a4-8b48-442c-9678-e93814c643a3', N'01064797626', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[CustomAppointments] ON 

INSERT [dbo].[CustomAppointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (1, N'22:30', 1, NULL, 23, 0)
INSERT [dbo].[CustomAppointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (2, N'22:30', 1, NULL, 23, 0)
INSERT [dbo].[CustomAppointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (3, N'22:30', 1, NULL, 23, 0)
INSERT [dbo].[CustomAppointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (4, N'22:30', 1, NULL, 23, 0)
INSERT [dbo].[CustomAppointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (5, N'22:30', 1, NULL, 23, 0)
INSERT [dbo].[CustomAppointments] ([Id], [LectureDate], [DayOfWeek], [Status], [InstructorSubjectBridgeID], [IsDeleted]) VALUES (6, N'22:30', 1, NULL, 23, 0)
SET IDENTITY_INSERT [dbo].[CustomAppointments] OFF
GO
INSERT [dbo].[Instructors] ([applicationUserID], [status]) VALUES (N'9e2345c2-bbbe-4536-9f73-19e5e727ba09', 1)
INSERT [dbo].[Instructors] ([applicationUserID], [status]) VALUES (N'b9587fd4-91bd-4b6c-b9a0-224f1292a486', 1)
INSERT [dbo].[Instructors] ([applicationUserID], [status]) VALUES (N'd682ca81-f18b-41f6-8ff2-5fa40c29f341', 1)
INSERT [dbo].[Instructors] ([applicationUserID], [status]) VALUES (N'ea082751-997d-4b22-8b5e-7194359e4917', 0)
INSERT [dbo].[Instructors] ([applicationUserID], [status]) VALUES (N'fbd3fd6a-8af5-4be6-9aa0-803507008c87', 1)
GO
SET IDENTITY_INSERT [dbo].[InstructorSubjects] ON 

INSERT [dbo].[InstructorSubjects] ([Id], [SubjectID], [InstructorID], [IsDeleted]) VALUES (23, 1, N'fbd3fd6a-8af5-4be6-9aa0-803507008c87', 0)
SET IDENTITY_INSERT [dbo].[InstructorSubjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 

INSERT [dbo].[Requests] ([Id], [Grade], [NumberOfHouers], [status], [StudentID], [IsDeleted]) VALUES (21, N'الصف الرابع', NULL, 0, N'34df12f1-d7fd-4fd4-889c-e00bea79b9a8', 0)
INSERT [dbo].[Requests] ([Id], [Grade], [NumberOfHouers], [status], [StudentID], [IsDeleted]) VALUES (22, N'الرابع', NULL, 0, N'34df12f1-d7fd-4fd4-889c-e00bea79b9a8', 0)
INSERT [dbo].[Requests] ([Id], [Grade], [NumberOfHouers], [status], [StudentID], [IsDeleted]) VALUES (23, N'الصف الرابع', NULL, 0, N'34df12f1-d7fd-4fd4-889c-e00bea79b9a8', 0)
INSERT [dbo].[Requests] ([Id], [Grade], [NumberOfHouers], [status], [StudentID], [IsDeleted]) VALUES (24, N'الصف السادس', NULL, 0, N'2755130b-2868-444e-b407-93ae4b6dfaaf', 0)
INSERT [dbo].[Requests] ([Id], [Grade], [NumberOfHouers], [status], [StudentID], [IsDeleted]) VALUES (25, N'الصف الحادي عشر', 10, 0, N'2755130b-2868-444e-b407-93ae4b6dfaaf', 0)
INSERT [dbo].[Requests] ([Id], [Grade], [NumberOfHouers], [status], [StudentID], [IsDeleted]) VALUES (26, N'الصف العاشر', 10, 0, N'2755130b-2868-444e-b407-93ae4b6dfaaf', 0)
INSERT [dbo].[Requests] ([Id], [Grade], [NumberOfHouers], [status], [StudentID], [IsDeleted]) VALUES (27, N'الصف العاشر', 10, 0, N'2755130b-2868-444e-b407-93ae4b6dfaaf', 0)
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
INSERT [dbo].[Students] ([ApplicationUserID]) VALUES (N'2755130b-2868-444e-b407-93ae4b6dfaaf')
INSERT [dbo].[Students] ([ApplicationUserID]) VALUES (N'34df12f1-d7fd-4fd4-889c-e00bea79b9a8')
INSERT [dbo].[Students] ([ApplicationUserID]) VALUES (N'43a4ee4d-d2dd-4945-8565-1792957a1573')
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id], [Name], [Grade], [IsDeleted]) VALUES (1, N'عربى', 1, 0)
INSERT [dbo].[Subjects] ([Id], [Name], [Grade], [IsDeleted]) VALUES (2, N'انجلش', 1, 0)
INSERT [dbo].[Subjects] ([Id], [Name], [Grade], [IsDeleted]) VALUES (3, N'كيمياء', 2, 0)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
ALTER TABLE [dbo].[Instructors] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[InstructorSubjects] ADD  DEFAULT ((0)) FOR [SubjectID]
GO
ALTER TABLE [dbo].[InstructorSubjects] ADD  DEFAULT (N'') FOR [InstructorID]
GO
ALTER TABLE [dbo].[OtherRequests] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT ((0)) FOR [Grade]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_InstructorSubjects_InstructorSubjectBridgeID] FOREIGN KEY([InstructorSubjectBridgeID])
REFERENCES [dbo].[InstructorSubjects] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_InstructorSubjects_InstructorSubjectBridgeID]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CustomAppointments]  WITH CHECK ADD  CONSTRAINT [FK_CustomAppointments_InstructorSubjects_InstructorSubjectBridgeID] FOREIGN KEY([InstructorSubjectBridgeID])
REFERENCES [dbo].[InstructorSubjects] ([Id])
GO
ALTER TABLE [dbo].[CustomAppointments] CHECK CONSTRAINT [FK_CustomAppointments_InstructorSubjects_InstructorSubjectBridgeID]
GO
ALTER TABLE [dbo].[Instructors]  WITH CHECK ADD  CONSTRAINT [FK_Instructors_AspNetUsers_applicationUserID] FOREIGN KEY([applicationUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Instructors] CHECK CONSTRAINT [FK_Instructors_AspNetUsers_applicationUserID]
GO
ALTER TABLE [dbo].[InstructorSubjects]  WITH CHECK ADD  CONSTRAINT [FK_InstructorSubjects_Instructors_InstructorID] FOREIGN KEY([InstructorID])
REFERENCES [dbo].[Instructors] ([applicationUserID])
GO
ALTER TABLE [dbo].[InstructorSubjects] CHECK CONSTRAINT [FK_InstructorSubjects_Instructors_InstructorID]
GO
ALTER TABLE [dbo].[InstructorSubjects]  WITH CHECK ADD  CONSTRAINT [FK_InstructorSubjects_Subjects_SubjectID] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[InstructorSubjects] CHECK CONSTRAINT [FK_InstructorSubjects_Subjects_SubjectID]
GO
ALTER TABLE [dbo].[RequestAppointments]  WITH CHECK ADD  CONSTRAINT [FK_RequestAppointments_Appointments_AppointmentID] FOREIGN KEY([CustomAppointmentID])
REFERENCES [dbo].[Appointments] ([Id])
GO
ALTER TABLE [dbo].[RequestAppointments] CHECK CONSTRAINT [FK_RequestAppointments_Appointments_AppointmentID]
GO
ALTER TABLE [dbo].[RequestAppointments]  WITH CHECK ADD  CONSTRAINT [FK_RequestAppointments_CustomAppointments_CustomAppointmentID] FOREIGN KEY([CustomAppointmentID])
REFERENCES [dbo].[CustomAppointments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestAppointments] CHECK CONSTRAINT [FK_RequestAppointments_CustomAppointments_CustomAppointmentID]
GO
ALTER TABLE [dbo].[RequestAppointments]  WITH CHECK ADD  CONSTRAINT [FK_RequestAppointments_Requests_RequestID] FOREIGN KEY([RequestID])
REFERENCES [dbo].[Requests] ([Id])
GO
ALTER TABLE [dbo].[RequestAppointments] CHECK CONSTRAINT [FK_RequestAppointments_Requests_RequestID]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Students_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ApplicationUserID])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Students_StudentID]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_AspNetUsers_ApplicationUserID] FOREIGN KEY([ApplicationUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_AspNetUsers_ApplicationUserID]
GO
