USE [Sistema_Barberia]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] [int] NOT NULL,
	[Cliente] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](9) NOT NULL,
	[Correo] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id_Empleado] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](9) NOT NULL,
	[Correo] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Dui] [nvarchar](10) NOT NULL,
	[Contraseña] [nvarchar](20) NOT NULL,
	[Id_Rol] [int] NOT NULL,
	[Id_Sucursal] [int] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[Id_Movimiento] [int] NOT NULL,
	[Precio_Total] [decimal](18, 2) NOT NULL,
	[Cantidad_Total] [int] NOT NULL,
	[Observacion] [nvarchar](100) NOT NULL,
	[Tipo_Movimiento] [nvarchar](10) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Id_Cliente] [int] NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[Id_Movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento_Producto]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento_Producto](
	[Id_Movimiento_Producto] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Id_Sucursal_Producto] [int] NOT NULL,
	[Id_Movimiento] [int] NOT NULL,
 CONSTRAINT [PK_Movimiento_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_Movimiento_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id_Producto] [int] NOT NULL,
	[Producto] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id_Rol] [int] NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Id_Sucursal] [int] NOT NULL,
	[Sucursal] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Id_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal_Producto]    Script Date: 31/03/2024 0:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal_Producto](
	[Id_Sucursal_Producto] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[Stock_Min] [int] NOT NULL,
	[Id_Sucursal] [int] NOT NULL,
	[Id_Producto] [int] NOT NULL,
 CONSTRAINT [PK_Sucursal_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_Sucursal_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Rol] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Rol] ([Id_Rol])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Rol]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Sucursal] FOREIGN KEY([Id_Sucursal])
REFERENCES [dbo].[Sucursal] ([Id_Sucursal])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Sucursal]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cliente] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cliente]
GO
ALTER TABLE [dbo].[Movimiento_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Producto_Movimiento] FOREIGN KEY([Id_Movimiento])
REFERENCES [dbo].[Movimiento] ([Id_Movimiento])
GO
ALTER TABLE [dbo].[Movimiento_Producto] CHECK CONSTRAINT [FK_Movimiento_Producto_Movimiento]
GO
ALTER TABLE [dbo].[Movimiento_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Producto_Sucursal_Producto] FOREIGN KEY([Id_Sucursal_Producto])
REFERENCES [dbo].[Sucursal_Producto] ([Id_Sucursal_Producto])
GO
ALTER TABLE [dbo].[Movimiento_Producto] CHECK CONSTRAINT [FK_Movimiento_Producto_Sucursal_Producto]
GO
ALTER TABLE [dbo].[Sucursal_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Producto_Producto] FOREIGN KEY([Id_Producto])
REFERENCES [dbo].[Producto] ([Id_Producto])
GO
ALTER TABLE [dbo].[Sucursal_Producto] CHECK CONSTRAINT [FK_Sucursal_Producto_Producto]
GO
ALTER TABLE [dbo].[Sucursal_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Producto_Sucursal] FOREIGN KEY([Id_Sucursal])
REFERENCES [dbo].[Sucursal] ([Id_Sucursal])
GO
ALTER TABLE [dbo].[Sucursal_Producto] CHECK CONSTRAINT [FK_Sucursal_Producto_Sucursal]
GO
