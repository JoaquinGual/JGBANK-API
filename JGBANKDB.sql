
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/3/2022 17:54:06 ******/
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
/****** Object:  Table [dbo].[Compras_Dolares]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras_Dolares](
	[idCompra] [int] IDENTITY(0,1) NOT NULL,
	[montoPesos] [float] NOT NULL,
	[montoDolar] [float] NOT NULL,
	[fechaCompra] [date] NOT NULL,
	[valorDolar] [float] NOT NULL,
	[idCuenta] [int] NOT NULL,
 CONSTRAINT [Compras_Dolares_pk] PRIMARY KEY CLUSTERED 
(
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[idCuenta] [int] IDENTITY(0,1) NOT NULL,
	[numCuenta] [varchar](50) NOT NULL,
	[idTipo] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[saldo] [float] NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [Cuentas_pk] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depositos]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depositos](
	[idDeposito] [int] IDENTITY(0,1) NOT NULL,
	[montoDeposito] [float] NOT NULL,
	[fechaDeposito] [date] NOT NULL,
	[idCuenta] [int] NOT NULL,
 CONSTRAINT [Depositos_pk] PRIMARY KEY CLUSTERED 
(
	[idDeposito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direcciones]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direcciones](
	[idDireccion] [int] IDENTITY(0,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[calle] [varchar](50) NOT NULL,
	[numero] [int] NOT NULL,
 CONSTRAINT [Direcciones_pk] PRIMARY KEY CLUSTERED 
(
	[idDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexos]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexos](
	[idSexo] [int] IDENTITY(0,1) NOT NULL,
	[sexo] [varchar](20) NOT NULL,
 CONSTRAINT [Sexos_pk] PRIMARY KEY CLUSTERED 
(
	[idSexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[idTarjeta] [int] IDENTITY(0,1) NOT NULL,
	[numTarjeta] [nvarchar](16) NOT NULL,
	[idTipo] [int] NOT NULL,
	[fec_expedicion] [date] NOT NULL,
	[fec_vencimiento] [date] NOT NULL,
	[ccv] [int] NOT NULL,
	[estado] [bit] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [Tarjetas_pk] PRIMARY KEY CLUSTERED 
(
	[idTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefonos]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefonos](
	[idTelefono] [int] IDENTITY(0,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[numTel] [varchar](50) NOT NULL,
 CONSTRAINT [Telefonos_pk] PRIMARY KEY CLUSTERED 
(
	[idTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Cuentas]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Cuentas](
	[idTipo] [int] IDENTITY(0,1) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
 CONSTRAINT [Tipos_Cuentas_pk] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Tarjetas]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Tarjetas](
	[idTipo] [int] IDENTITY(0,1) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
 CONSTRAINT [Tipos_Tarjetas_pk] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transferencias]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transferencias](
	[idTransferencia] [int] IDENTITY(0,1) NOT NULL,
	[monto] [float] NOT NULL,
	[fecha_trans] [date] NOT NULL,
	[idCuentaSalida] [int] NOT NULL,
	[idCuentaDestino] [int] NOT NULL,
 CONSTRAINT [Transferencias_pk] PRIMARY KEY CLUSTERED 
(
	[idTransferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(0,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[numdoc] [int] NOT NULL,
	[tipodoc] [int] NOT NULL,
	[fecha_nac] [date] NOT NULL,
	[idSexo] [int] NOT NULL,
	[foto_perfil] [image] NULL,
	[cuil] [bigint] NOT NULL,
	[email] [varchar](50) NULL,
	[contrasenia] [varchar](50) NULL,
	[token] [varchar](max) NULL,
 CONSTRAINT [Usuarios_pk] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta_Dolares]    Script Date: 4/3/2022 17:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta_Dolares](
	[idVenta] [int] IDENTITY(0,1) NOT NULL,
	[montoDolar] [float] NOT NULL,
	[montoPesos] [float] NOT NULL,
	[fechaVenta] [date] NOT NULL,
	[valorDolar] [float] NOT NULL,
	[idCuenta] [int] NOT NULL,
 CONSTRAINT [Venta_Dolares_pk] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([idCuenta], [numCuenta], [idTipo], [idUsuario], [saldo], [estado]) VALUES (0, N'79774', 0, 2, 30000, 1)
INSERT [dbo].[Cuentas] ([idCuenta], [numCuenta], [idTipo], [idUsuario], [saldo], [estado]) VALUES (1, N'91499', 1, 2, 250, 1)
INSERT [dbo].[Cuentas] ([idCuenta], [numCuenta], [idTipo], [idUsuario], [saldo], [estado]) VALUES (2, N'15426', 0, 0, 15000, 1)
INSERT [dbo].[Cuentas] ([idCuenta], [numCuenta], [idTipo], [idUsuario], [saldo], [estado]) VALUES (3, N'31653', 1, 0, 150, 1)
INSERT [dbo].[Cuentas] ([idCuenta], [numCuenta], [idTipo], [idUsuario], [saldo], [estado]) VALUES (4, N'86958', 0, 3, 40000, 1)
INSERT [dbo].[Cuentas] ([idCuenta], [numCuenta], [idTipo], [idUsuario], [saldo], [estado]) VALUES (6, N'52705', 0, 5, 0, 0)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Sexos] ON 

INSERT [dbo].[Sexos] ([idSexo], [sexo]) VALUES (0, N'Masculino')
SET IDENTITY_INSERT [dbo].[Sexos] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipos_Cuentas] ON 

INSERT [dbo].[Tipos_Cuentas] ([idTipo], [tipo]) VALUES (0, N'Caja de Ahorro en Pesos')
INSERT [dbo].[Tipos_Cuentas] ([idTipo], [tipo]) VALUES (1, N'Caja de Ahorro en Dolares')
SET IDENTITY_INSERT [dbo].[Tipos_Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [nombre], [apellido], [numdoc], [tipodoc], [fecha_nac], [idSexo], [foto_perfil], [cuil], [email], [contrasenia], [token]) VALUES (0, N'Joaquin', N'Gual', 41152548, 0, CAST(N'1998-04-27' AS Date), 0, NULL, 20411525474, N'joaquingual1@gmail.com', N'joita', N'1b87d4fa-70d3-43ef-a5b4-6b5dccd306b0')
INSERT [dbo].[Usuarios] ([idUsuario], [nombre], [apellido], [numdoc], [tipodoc], [fecha_nac], [idSexo], [foto_perfil], [cuil], [email], [contrasenia], [token]) VALUES (2, N'Fede', N'Celiz', 1234, 0, CAST(N'1992-03-04' AS Date), 0, NULL, 2044646, N'fede@gmail.com', N'hola', N'a821327e-fcf8-4f63-a855-9f60a5f75b0a')
INSERT [dbo].[Usuarios] ([idUsuario], [nombre], [apellido], [numdoc], [tipodoc], [fecha_nac], [idSexo], [foto_perfil], [cuil], [email], [contrasenia], [token]) VALUES (3, N'Luciano', N'Litwin', 44191844, 0, CAST(N'2002-05-18' AS Date), 0, NULL, 20441918448, N'lucho@gmail.com', N'hola', NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [nombre], [apellido], [numdoc], [tipodoc], [fecha_nac], [idSexo], [foto_perfil], [cuil], [email], [contrasenia], [token]) VALUES (4, N'Nico', N'Rodriguez', 41569876, 0, CAST(N'1998-05-12' AS Date), 0, NULL, 20415698764, N'nico@g.com', N'nico', NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [nombre], [apellido], [numdoc], [tipodoc], [fecha_nac], [idSexo], [foto_perfil], [cuil], [email], [contrasenia], [token]) VALUES (5, N'Lucas', N'Muñoz', 38565654, 0, CAST(N'1996-05-15' AS Date), 0, NULL, 20385656545, N'pela@gmail.com', N'pelado', NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Compras_Dolares]  WITH CHECK ADD  CONSTRAINT [Compras_Dolares_Cuentas] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuentas] ([idCuenta])
GO
ALTER TABLE [dbo].[Compras_Dolares] CHECK CONSTRAINT [Compras_Dolares_Cuentas]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [Cuentas_Tipos_Cuentas] FOREIGN KEY([idTipo])
REFERENCES [dbo].[Tipos_Cuentas] ([idTipo])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [Cuentas_Tipos_Cuentas]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [Cuentas_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [Cuentas_Usuarios]
GO
ALTER TABLE [dbo].[Depositos]  WITH CHECK ADD  CONSTRAINT [Depositos_Cuentas] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuentas] ([idCuenta])
GO
ALTER TABLE [dbo].[Depositos] CHECK CONSTRAINT [Depositos_Cuentas]
GO
ALTER TABLE [dbo].[Direcciones]  WITH CHECK ADD  CONSTRAINT [Direcciones_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Direcciones] CHECK CONSTRAINT [Direcciones_Usuarios]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [Tarjetas_Tipos_Tarjetas] FOREIGN KEY([idTipo])
REFERENCES [dbo].[Tipos_Tarjetas] ([idTipo])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [Tarjetas_Tipos_Tarjetas]
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [Tarjetas_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Tarjetas] CHECK CONSTRAINT [Tarjetas_Usuarios]
GO
ALTER TABLE [dbo].[Telefonos]  WITH CHECK ADD  CONSTRAINT [Telefonos_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Telefonos] CHECK CONSTRAINT [Telefonos_Usuarios]
GO
ALTER TABLE [dbo].[Transferencias]  WITH CHECK ADD  CONSTRAINT [Transferencias_CuentaDestino] FOREIGN KEY([idCuentaSalida])
REFERENCES [dbo].[Cuentas] ([idCuenta])
GO
ALTER TABLE [dbo].[Transferencias] CHECK CONSTRAINT [Transferencias_CuentaDestino]
GO
ALTER TABLE [dbo].[Transferencias]  WITH CHECK ADD  CONSTRAINT [Transferencias_CuentaSalida] FOREIGN KEY([idCuentaDestino])
REFERENCES [dbo].[Cuentas] ([idCuenta])
GO
ALTER TABLE [dbo].[Transferencias] CHECK CONSTRAINT [Transferencias_CuentaSalida]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [Usuarios_Sexos] FOREIGN KEY([idSexo])
REFERENCES [dbo].[Sexos] ([idSexo])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [Usuarios_Sexos]
GO
ALTER TABLE [dbo].[Venta_Dolares]  WITH CHECK ADD  CONSTRAINT [Venta_Dolares_Cuentas] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuentas] ([idCuenta])
GO
ALTER TABLE [dbo].[Venta_Dolares] CHECK CONSTRAINT [Venta_Dolares_Cuentas]
GO
USE [master]
GO
ALTER DATABASE [JGBANK] SET  READ_WRITE 
GO
