using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JGBANK.Models
{
    public partial class JGBANKContext : DbContext
    {
        public JGBANKContext()
        {
        }

        public JGBANKContext(DbContextOptions<JGBANKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComprasDolare> ComprasDolares { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Deposito> Depositos { get; set; }
        public virtual DbSet<Direccione> Direcciones { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Tarjeta> Tarjetas { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }
        public virtual DbSet<TiposCuenta> TiposCuentas { get; set; }
        public virtual DbSet<TiposTarjeta> TiposTarjetas { get; set; }
        public virtual DbSet<Transferencia> Transferencias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<VentaDolare> VentaDolares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JGUAL\\JOAQUIN;Database=JGBANK;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ComprasDolare>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("Compras_Dolares_pk");

                entity.ToTable("Compras_Dolares");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.MontoDolar).HasColumnName("montoDolar");

                entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");

                entity.Property(e => e.ValorDolar).HasColumnName("valorDolar");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.ComprasDolares)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Compras_Dolares_Cuentas");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("Cuentas_pk");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumCuenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numCuenta");

                entity.Property(e => e.Saldo).HasColumnName("saldo");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cuentas_Tipos_Cuentas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cuentas_Usuarios");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.HasKey(e => e.IdDeposito)
                    .HasName("Depositos_pk");

                entity.Property(e => e.IdDeposito).HasColumnName("idDeposito");

                entity.Property(e => e.FechaDeposito)
                    .HasColumnType("date")
                    .HasColumnName("fechaDeposito");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.MontoDeposito).HasColumnName("montoDeposito");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Depositos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Depositos_Cuentas");
            });

            modelBuilder.Entity<Direccione>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("Direcciones_pk");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("calle");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Direcciones_Usuarios");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.IdSexo)
                    .HasName("Sexos_pk");

                entity.Property(e => e.IdSexo).HasColumnName("idSexo");

                entity.Property(e => e.Sexo1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sexo");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("Tarjetas_pk");

                entity.Property(e => e.IdTarjeta).HasColumnName("idTarjeta");

                entity.Property(e => e.Ccv).HasColumnName("ccv");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FecExpedicion)
                    .HasColumnType("date")
                    .HasColumnName("fec_expedicion");

                entity.Property(e => e.FecVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fec_vencimiento");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumTarjeta)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("numTarjeta");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tarjetas_Tipos_Tarjetas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tarjetas_Usuarios");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.HasKey(e => e.IdTelefono)
                    .HasName("Telefonos_pk");

                entity.Property(e => e.IdTelefono).HasColumnName("idTelefono");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NumTel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numTel");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Telefonos_Usuarios");
            });

            modelBuilder.Entity<TiposCuenta>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("Tipos_Cuentas_pk");

                entity.ToTable("Tipos_Cuentas");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<TiposTarjeta>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("Tipos_Tarjetas_pk");

                entity.ToTable("Tipos_Tarjetas");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Transferencia>(entity =>
            {
                entity.HasKey(e => e.IdTransferencia)
                    .HasName("Transferencias_pk");

                entity.Property(e => e.IdTransferencia).HasColumnName("idTransferencia");

                entity.Property(e => e.FechaTrans)
                    .HasColumnType("date")
                    .HasColumnName("fecha_trans");

                entity.Property(e => e.IdCuentaDestino).HasColumnName("idCuentaDestino");

                entity.Property(e => e.IdCuentaSalida).HasColumnName("idCuentaSalida");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdCuentaDestinoNavigation)
                    .WithMany(p => p.TransferenciaIdCuentaDestinoNavigations)
                    .HasForeignKey(d => d.IdCuentaDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transferencias_CuentaSalida");

                entity.HasOne(d => d.IdCuentaSalidaNavigation)
                    .WithMany(p => p.TransferenciaIdCuentaSalidaNavigations)
                    .HasForeignKey(d => d.IdCuentaSalida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transferencias_CuentaDestino");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("Usuarios_pk");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Cuil).HasColumnName("cuil");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaNac)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nac");

                entity.Property(e => e.FotoPerfil)
                    .HasColumnType("image")
                    .HasColumnName("foto_perfil");

                entity.Property(e => e.IdSexo).HasColumnName("idSexo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Numdoc).HasColumnName("numdoc");

                entity.Property(e => e.Tipodoc).HasColumnName("tipodoc");

                entity.Property(e => e.Token)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuarios_Sexos");
            });

            modelBuilder.Entity<VentaDolare>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("Venta_Dolares_pk");

                entity.ToTable("Venta_Dolares");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fechaVenta");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.MontoDolar).HasColumnName("montoDolar");

                entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");

                entity.Property(e => e.ValorDolar).HasColumnName("valorDolar");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.VentaDolares)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Venta_Dolares_Cuentas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
