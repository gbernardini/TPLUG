USE [master]
GO
/****** Object:  Database [TPLUG]    Script Date: 07/11/2022 09:26:34 a. m. ******/
CREATE DATABASE [TPLUG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP LUG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TP LUG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP LUG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TP LUG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TPLUG] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPLUG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPLUG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPLUG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPLUG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPLUG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPLUG] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPLUG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TPLUG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPLUG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPLUG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPLUG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPLUG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPLUG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPLUG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPLUG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPLUG] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TPLUG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPLUG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPLUG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPLUG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPLUG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPLUG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPLUG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPLUG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TPLUG] SET  MULTI_USER 
GO
ALTER DATABASE [TPLUG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPLUG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TPLUG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TPLUG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TPLUG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TPLUG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TPLUG] SET QUERY_STORE = OFF
GO
USE [TPLUG]
GO
/****** Object:  Table [dbo].[Duenio]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duenio](
	[duenioId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](20) NOT NULL,
	[mascotaId] [int] NOT NULL,
 CONSTRAINT [PK_Duenio] PRIMARY KEY CLUSTERED 
(
	[duenioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascota]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascota](
	[mascotaId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](20) NOT NULL,
	[energia] [int] NOT NULL,
	[felicidad] [int] NOT NULL,
	[tieneColaLarga] [bit] NULL,
	[tamanio] [nchar](20) NULL,
	[tienePelo] [bit] NULL,
	[tienePlumas] [bit] NULL,
	[idioma] [nchar](20) NULL,
	[clase] [int] NOT NULL,
 CONSTRAINT [PK_Mascota] PRIMARY KEY CLUSTERED 
(
	[mascotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paseador]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paseador](
	[paseadorId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](20) NOT NULL,
	[cantMaxMascotas] [int] NOT NULL,
 CONSTRAINT [PK_Paseador] PRIMARY KEY CLUSTERED 
(
	[paseadorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paseo]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paseo](
	[paseoId] [int] IDENTITY(1,1) NOT NULL,
	[paseadorId] [int] NOT NULL,
	[mascotaId] [int] NOT NULL,
	[distancia] [int] NOT NULL,
	[pendiente] [bit] NOT NULL,
 CONSTRAINT [PK_Paseo] PRIMARY KEY CLUSTERED 
(
	[paseoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[username] [nchar](20) NOT NULL,
	[password] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Duenio]  WITH CHECK ADD  CONSTRAINT [FK_Duenio_Mascota] FOREIGN KEY([mascotaId])
REFERENCES [dbo].[Mascota] ([mascotaId])
GO
ALTER TABLE [dbo].[Duenio] CHECK CONSTRAINT [FK_Duenio_Mascota]
GO
ALTER TABLE [dbo].[Paseo]  WITH CHECK ADD  CONSTRAINT [FK_Paseo_Mascota] FOREIGN KEY([mascotaId])
REFERENCES [dbo].[Mascota] ([mascotaId])
GO
ALTER TABLE [dbo].[Paseo] CHECK CONSTRAINT [FK_Paseo_Mascota]
GO
ALTER TABLE [dbo].[Paseo]  WITH CHECK ADD  CONSTRAINT [FK_Paseo_Paseador] FOREIGN KEY([paseadorId])
REFERENCES [dbo].[Paseador] ([paseadorId])
GO
ALTER TABLE [dbo].[Paseo] CHECK CONSTRAINT [FK_Paseo_Paseador]
GO
/****** Object:  StoredProcedure [dbo].[CrearDuenio]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearDuenio]

	@nombre varchar(50),
	@mascotaId int

AS
BEGIN
	
	SET NOCOUNT ON;

INSERT INTO Duenio
	(nombre,mascotaId)
     VALUES
    (@nombre,@mascotaId)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearMascota]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearMascota] 
	@nombre varchar(50),
	@energia int,
	@felicidad int,
	@tieneColaLarga bit = NULL,
	@tamanio varchar(50) = NULL,
	@tienePelo bit = NULL,
	@tienePlumas bit = NULL,
	@idioma varchar(50) = NULL,
	@clase int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Mascota (nombre, energia, felicidad, tieneColaLarga, tamanio, tienePelo, tienePlumas, idioma,clase) 
	VALUES(@nombre, @energia, @felicidad, @tieneColaLarga, @tamanio, @tienePelo, @tienePlumas, @idioma, @clase)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearPaseador]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearPaseador] 
	@nombre varchar(50),
	@cantMaxMascotas int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Paseador (nombre, cantMaxMascotas) 
	VALUES(@nombre, @cantMaxMascotas) 
END
GO
/****** Object:  StoredProcedure [dbo].[CrearPaseo]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CrearPaseo] 
	@codigoPaseador int,
	@codigoMascota int,
	@distancia Int

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Paseo (paseadorId, mascotaId, distancia, pendiente) 
	VALUES (@codigoPaseador, @codigoMascota, @distancia, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[ExisteDuenio]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExisteDuenio] 
	@nombre varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM TPLUG.dbo.Duenio
	WHERE nombre = @nombre
END
GO
/****** Object:  StoredProcedure [dbo].[ExisteMascota]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExisteMascota] 
	@nombre varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM TPLUG.dbo.Mascota
	WHERE nombre = @nombre
END
GO
/****** Object:  StoredProcedure [dbo].[ExistePaseador]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExistePaseador] 
	@nombre varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM TPLUG.dbo.Paseador
	WHERE nombre = @nombre
END
GO
/****** Object:  StoredProcedure [dbo].[ExisteUsuario]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExisteUsuario]

	@nombreUsuario varchar(50),
	@contrasenia varchar(50)

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM TPLUG.dbo.Usuario
	WHERE username = @nombreUsuario AND password = @contrasenia

END

GO
/****** Object:  StoredProcedure [dbo].[ListarDuenios]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarDuenios] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TPLUG.dbo.Duenio
END
GO
/****** Object:  StoredProcedure [dbo].[ListarMascotas]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarMascotas] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TPLUG.dbo.Mascota
END
GO
/****** Object:  StoredProcedure [dbo].[ListarMascotaXId]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarMascotaXId] 
	@codigo int

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM TPLUG.dbo.Mascota
	WHERE mascotaId = @codigo
END
GO
/****** Object:  StoredProcedure [dbo].[ListarMascotaXNombre]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarMascotaXNombre] 
	@nombre varchar(50)

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM TPLUG.dbo.Mascota
	WHERE nombre = @nombre
END
GO
/****** Object:  StoredProcedure [dbo].[ListarPaseadores]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarPaseadores] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM TPLUG.dbo.Paseador
END
GO
/****** Object:  StoredProcedure [dbo].[ListarPaseadorXCodigo]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarPaseadorXCodigo] 
	@codigo int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM TPLUG.dbo.Paseador
	WHERE paseadorId = @codigo
END
GO
/****** Object:  StoredProcedure [dbo].[ListarPaseoXEstadoXPaseador]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarPaseoXEstadoXPaseador] 
	@codigo int,
	@estado bit
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Paseo 
	WHERE paseadorId = @codigo AND pendiente = @estado
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarMascota]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarMascota] 
	@codigo int,
	@felicidad int,
	@energia int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Mascota 
	SET felicidad = @felicidad, energia = @energia
	WHERE mascotaId = @codigo
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarPaseo]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarPaseo] 
	@codigo int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Paseo 
	SET pendiente = 0
	WHERE paseoId = @codigo
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDistanciaRecorridaPaseador]    Script Date: 07/11/2022 09:26:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerDistanciaRecorridaPaseador] 
	@codigo int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT SUM(distancia) FROM Paseo 
	WHERE paseadorId = @codigo  AND pendiente = 0
END
GO
USE [master]
GO
ALTER DATABASE [TPLUG] SET  READ_WRITE 
GO
