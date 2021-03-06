USE [qbdproducto]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 08/02/2022 05:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Stock], [FechaRegistro]) VALUES (1, N'Puerta', CAST(235.00 AS Decimal(18, 2)), 15, CAST(N'2022-02-08T16:11:55.383' AS DateTime))
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Stock], [FechaRegistro]) VALUES (3, N'Compuerta', CAST(15.00 AS Decimal(18, 2)), 46, CAST(N'2022-02-08T20:26:23.027' AS DateTime))
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Stock], [FechaRegistro]) VALUES (5, N'NuevoCampo', CAST(2.00 AS Decimal(18, 2)), 6, CAST(N'2022-02-08T21:02:30.830' AS DateTime))
SET IDENTITY_INSERT [dbo].[Producto] OFF
/****** Object:  StoredProcedure [dbo].[sp_CreateProducto]    Script Date: 08/02/2022 05:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateProducto]
@Nombre nvarchar(50), 
@Precio decimal(18,2), 
@Cantidad int,
@Fecha datetime,
@id int output
AS
BEGIN
SET NOCOUNT ON;
--DECLARE @id AS INT
INSERT INTO Producto (Nombre, Precio, Stock, FechaRegistro) 
VALUES (@Nombre,@Precio,@Cantidad,@Fecha)
SET @id=SCOPE_IDENTITY()
RETURN  @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProducto]    Script Date: 08/02/2022 05:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteProducto]
@idProducto int
AS
BEGIN
SET NOCOUNT ON;
DELETE FROM Producto WHERE Id = @idProducto;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProductos]    Script Date: 08/02/2022 05:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllProductos]
AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM Producto
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOneProducto]    Script Date: 08/02/2022 05:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetOneProducto]
@idProducto int
AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM Producto p where p.Id = @idProducto
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateProducto]    Script Date: 08/02/2022 05:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateProducto]
@idProducto int,
@Nombre nvarchar(50), 
@Precio decimal(18,2), 
@Cantidad int,
@Fecha datetime
AS
BEGIN
SET NOCOUNT ON;
UPDATE Producto 
SET Nombre = @Nombre, Precio = @Precio, 
@Fecha= @Fecha
WHERE Id = @idProducto
END
GO
