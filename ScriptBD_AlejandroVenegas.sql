USE [master]
GO

CREATE DATABASE [BuenPrecio] 
GO 

USE [BuenPrecio]
GO

CREATE SEQUENCE [DBO].[Secuencia_Venta] AS INT
 START WITH 1
 INCREMENT BY 1
GO
 
CREATE SEQUENCE [DBO].[Secuencia_Venta_Producto] AS INT
 START WITH 1
 INCREMENT BY 1
GO

 

CREATE TABLE [dbo].[Cajero](
	[Identificacion] [varchar](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [varchar](50) NOT NULL,
	[CajaAsignada] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Cajero] PRIMARY KEY CLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE TABLE [dbo].[Venta](
	[Codigo] [int] DEFAULT(NEXT VALUE FOR DBO.Secuencia_Venta)  NOT NULL,
	[Codigo_Cajero] [varchar](10) NOT NULL,
	[Fecha_Venta] [date] NOT NULL,
	[Monto_Total] [decimal](18,2) NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cajero] FOREIGN KEY([Codigo_Cajero])
REFERENCES [dbo].[Cajero] ([Identificacion])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cajero]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
CREATE TABLE [dbo].[Categoria](
	[Codigo] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Producto](
	[Codigo] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[CodigoCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CodigoCategoria])
REFERENCES [dbo].[Categoria] ([Codigo])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Venta_Producto](
	[Codigo] [int] DEFAULT(NEXT VALUE FOR DBO.Secuencia_Venta_Producto) NOT NULL,
	[Codigo_Venta] [int] NOT NULL,
	[Codigo_Producto] [int] NOT NULL,
	[Cantidad_Producto] [int] NOT NULL,

 CONSTRAINT [PK_Venta_Producto] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Venta_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Venta] FOREIGN KEY([Codigo_Venta])
REFERENCES [dbo].[Venta] ([Codigo])
GO
ALTER TABLE [dbo].[Venta_Producto] CHECK CONSTRAINT [FK_Venta]
GO

ALTER TABLE [dbo].[Venta_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto] FOREIGN KEY([Codigo_Producto])
REFERENCES [dbo].[Producto] ([codigo])
GO
ALTER TABLE [dbo].[Venta_Producto] CHECK CONSTRAINT [FK_Producto]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER dbo.triggerInsertVenta_Producto
   ON  dbo.venta_producto
   AFTER insert
AS 
BEGIN
	 
  SET NOCOUNT ON;

  DECLARE @ID INT, @CANTIDAD INT
  SELECT @ID = [Codigo_Producto], @CANTIDAD = [Cantidad_Producto]
  FROM INSERTED
   
  UPDATE producto 
  set [cantidad] = ([cantidad] - @CANTIDAD) WHERE 
  [dbo].[Producto].[Codigo]= @ID;
END
GO

USE [master]
GO
ALTER DATABASE [BuenPrecio] SET  READ_WRITE 
GO 

