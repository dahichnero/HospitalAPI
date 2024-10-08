USE [MedPatient]
GO
/****** Object:  Table [dbo].[Cabinet]    Script Date: 05.09.2024 18:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabinet](
	[CabinetId] [int] IDENTITY(1,1) NOT NULL,
	[CabinetNum] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Cabinet] PRIMARY KEY CLUSTERED 
(
	[CabinetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 05.09.2024 18:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorLastName] [nvarchar](50) NOT NULL,
	[DoctorName] [nvarchar](50) NOT NULL,
	[DoctorSurname] [nvarchar](50) NOT NULL,
	[Cabinet] [int] NOT NULL,
	[Specialization] [int] NOT NULL,
	[Sector] [int] NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 05.09.2024 18:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 05.09.2024 18:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[PatientLastName] [nvarchar](50) NOT NULL,
	[PatientName] [nvarchar](50) NOT NULL,
	[PatientSurName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Birth] [date] NOT NULL,
	[Gender] [int] NOT NULL,
	[Sector] [int] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 05.09.2024 18:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[SectorId] [int] IDENTITY(1,1) NOT NULL,
	[SectorNumber] [int] NOT NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY CLUSTERED 
(
	[SectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 05.09.2024 18:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[SpecializationId] [int] IDENTITY(1,1) NOT NULL,
	[SpecializationName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[SpecializationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cabinet] ON 

INSERT [dbo].[Cabinet] ([CabinetId], [CabinetNum]) VALUES (1, N'123')
INSERT [dbo].[Cabinet] ([CabinetId], [CabinetNum]) VALUES (2, N'100')
INSERT [dbo].[Cabinet] ([CabinetId], [CabinetNum]) VALUES (3, N'111')
INSERT [dbo].[Cabinet] ([CabinetId], [CabinetNum]) VALUES (4, N'234')
INSERT [dbo].[Cabinet] ([CabinetId], [CabinetNum]) VALUES (5, N'100a')
SET IDENTITY_INSERT [dbo].[Cabinet] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([DoctorId], [DoctorLastName], [DoctorName], [DoctorSurname], [Cabinet], [Specialization], [Sector]) VALUES (1, N'Лодочкина', N'Наталья', N'Владимировна', 2, 3, 1)
INSERT [dbo].[Doctor] ([DoctorId], [DoctorLastName], [DoctorName], [DoctorSurname], [Cabinet], [Specialization], [Sector]) VALUES (2, N'Петрушеваf', N'Надеждаf', N'Викторовнаf', 5, 5, 3)
INSERT [dbo].[Doctor] ([DoctorId], [DoctorLastName], [DoctorName], [DoctorSurname], [Cabinet], [Specialization], [Sector]) VALUES (1003, N'Новикова', N'Виктория', N'Александровна', 1, 1, 1)
INSERT [dbo].[Doctor] ([DoctorId], [DoctorLastName], [DoctorName], [DoctorSurname], [Cabinet], [Specialization], [Sector]) VALUES (1004, N'Новиков', N'Виктор', N'Александрович', 2, 1, 1)
INSERT [dbo].[Doctor] ([DoctorId], [DoctorLastName], [DoctorName], [DoctorSurname], [Cabinet], [Specialization], [Sector]) VALUES (1005, N'Чайка', N'Алеся', N'Викторовна', 5, 3, 2)
INSERT [dbo].[Doctor] ([DoctorId], [DoctorLastName], [DoctorName], [DoctorSurname], [Cabinet], [Specialization], [Sector]) VALUES (1006, N'Арсеньева', N'Мария', N'Сергеевна', 5, 2, 1)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (1, N'мужской')
INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (2, N'женский')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([PatientId], [PatientLastName], [PatientName], [PatientSurName], [Address], [Birth], [Gender], [Sector]) VALUES (1, N'Васильев', N'Артем', N'Николаевич', N'Улица Иллюминатов дом 34', CAST(N'2000-05-23' AS Date), 1, 2)
INSERT [dbo].[Patient] ([PatientId], [PatientLastName], [PatientName], [PatientSurName], [Address], [Birth], [Gender], [Sector]) VALUES (2, N'Баженова', N'Мишель', N'Витальевна', N'Улица Неизвестная дом 15', CAST(N'2000-06-03' AS Date), 2, 1)
INSERT [dbo].[Patient] ([PatientId], [PatientLastName], [PatientName], [PatientSurName], [Address], [Birth], [Gender], [Sector]) VALUES (2003, N'Орлова', N'Александра', N'Витальевна', N'Улица Рабочая дом 234', CAST(N'2000-07-01' AS Date), 1, 4)
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[Sector] ON 

INSERT [dbo].[Sector] ([SectorId], [SectorNumber]) VALUES (1, 1)
INSERT [dbo].[Sector] ([SectorId], [SectorNumber]) VALUES (2, 2)
INSERT [dbo].[Sector] ([SectorId], [SectorNumber]) VALUES (3, 3)
INSERT [dbo].[Sector] ([SectorId], [SectorNumber]) VALUES (4, 4)
INSERT [dbo].[Sector] ([SectorId], [SectorNumber]) VALUES (5, 5)
SET IDENTITY_INSERT [dbo].[Sector] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialization] ON 

INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (1, N'Стоматолог')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (2, N'Офтальмолог')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (3, N'ЛОР')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (4, N'Терапевт')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (5, N'Эндокринолог')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (6, N'Аллерголог')
SET IDENTITY_INSERT [dbo].[Specialization] OFF
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Cabinet] FOREIGN KEY([Cabinet])
REFERENCES [dbo].[Cabinet] ([CabinetId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Cabinet]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Sector] FOREIGN KEY([Sector])
REFERENCES [dbo].[Sector] ([SectorId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Sector]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Specialization] FOREIGN KEY([Specialization])
REFERENCES [dbo].[Specialization] ([SpecializationId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Specialization]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Gender]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Sector] FOREIGN KEY([Sector])
REFERENCES [dbo].[Sector] ([SectorId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Sector]
GO
