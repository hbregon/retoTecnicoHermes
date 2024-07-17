USE [master]
GO

/****** Object:  Database [AdministradorTareas]    Script Date: 7/11/2024 4:22:46 PM ******/
CREATE DATABASE [AdministradorTareas]
GO

USE [AdministradorTareas]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Colaborador](
	[IdColaborador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Colaborador] PRIMARY KEY CLUSTERED 
(
	[IdColaborador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tarea](
	[IdTarea] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estado] [varchar](30) NOT NULL,
	[Prioridad] [varchar](30) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[IdColaborador] [int] NULL,
	[Nota] [varchar](50) NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_Colaborador] FOREIGN KEY([IdColaborador])
REFERENCES [dbo].[Colaborador] ([IdColaborador])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [FK_Tarea_Colaborador]
GO

USE [AdministradorTareas]
GO

INSERT INTO [dbo].[Colaborador]
           ([Nombre]
           ,[Apellido])
     VALUES
           ('Hermes', 'Brenes'),
		   ('Juan', 'Perez'),
		   ('Ignacio', 'Herrera'),
		   ('Julian', 'Gonzalez'),
		   ('Mateo', 'López'),
		   ('Sebástian', 'Castro'),
		   ('Andrés', 'Brenes'),
		   ('José', 'Martinez'),
		   ('Jorge', 'Romero');
GO

USE [AdministradorTareas]
GO

INSERT INTO [dbo].[Tarea]
           ([Descripcion]
           ,[Estado]
           ,[Prioridad]
           ,[FechaInicio]
           ,[FechaFin]
           ,[IdColaborador]
           ,[Nota])
     VALUES
           ('Tarea 1','PENDIENTE','BAJA',GETDATE(), GETDATE(), NULL, 'Notas de la tarea 1'),
		   ('Tarea 2','EN PROCESO','MEDIA',GETDATE(), GETDATE(), 3, 'Notas de la tarea 2'),
		   ('Tarea 3','FINALIZADA','ALTA',GETDATE(), GETDATE(), 5, '')
GO
