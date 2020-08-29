using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SPV.Models;

namespace SPV.Service
{
    public partial class SPVContext : DbContext
    {
        public SPVContext()
        {
        }

        public SPVContext(DbContextOptions<SPVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<DetalleCompras> DetalleCompras { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolEmpleado> RolEmpleado { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.CorreoElectronico)
                    .HasName("correoElectronico")
                    .IsUnique();

                entity.HasIndex(e => e.NoNit)
                    .HasName("noNit")
                    .IsUnique();

                entity.Property(e => e.CorreoElectronico)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.NoNit)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoTelefono)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("idProveedor");

                entity.Property(e => e.NumeroFactura)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d._Empleado)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Compra_ibfk_2");

                entity.HasOne(d => d._Proveedor)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Compra_ibfk_1");
            });

            modelBuilder.Entity<DetalleCompras>(entity =>
            {
                entity.HasIndex(e => e.IdCompra)
                    .HasName("idCompra");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("idProducto");

                entity.Property(e => e.Iva).HasDefaultValueSql("'12'");

                entity.HasOne(d => d._Compra)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleCompras_ibfk_1");

                entity.HasOne(d => d._Producto)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleCompras_ibfk_2");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasIndex(e => e.IdProducto)
                    .HasName("idProducto");

                entity.HasIndex(e => e.IdVenta)
                    .HasName("idVenta");

                entity.HasOne(d => d._Producto)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleVenta_ibfk_2");

                entity.HasOne(d => d._Venta)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleVenta_ibfk_1");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasIndex(e => e.CorreoElectronico)
                    .HasName("correoElectronico")
                    .IsUnique();

                entity.HasIndex(e => e.IdGenero)
                    .HasName("idGenero");

                entity.HasIndex(e => e.NoNit)
                    .HasName("noNit")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CorreoElectronico)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.NoCelular)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoDpi)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoNit)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoTelefono)
                    .HasDefaultValueSql("'0'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d._Genero)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Empleado_ibfk_1");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.Numero)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Serie)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(e => e.Sexo)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.Property(e => e.Iva).HasDefaultValueSql("'12'");

                entity.HasOne(d => d._Producto)
                    .WithOne(p => p.Inventario)
                    .HasForeignKey<Inventario>(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_ibfk_1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.IdCategoria)
                    .HasName("idCategoria");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("idProveedor");

                entity.Property(e => e.Descripcion)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.Marca)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d._Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Producto_ibfk_1");

                entity.HasOne(d => d._Proveedor)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Producto_ibfk_2");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasIndex(e => e.CorreoElectronico)
                    .HasName("correoElectronico")
                    .IsUnique();

                entity.HasIndex(e => e.NoNit)
                    .HasName("noNit")
                    .IsUnique();

                entity.Property(e => e.CorreoElectronico)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.NoNit)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoTelefono)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RolEmpleado>(entity =>
            {
                entity.HasKey(e => new { e.IdRol, e.IdEmpleado })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.HasOne(d => d._Empleado)
                    .WithMany(p => p.RolEmpleado)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RolEmpleado_ibfk_1");

                entity.HasOne(d => d._Rol)
                    .WithMany(p => p.RolEmpleado)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RolEmpleado_ibfk_2");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Nombre)
                    .HasName("nombre")
                    .IsUnique();

                entity.Property(e => e.Clave)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sal)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d._Empleado)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_ibfk_1");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasIndex(e => e.IdCliente)
                    .HasName("idCliente");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.HasIndex(e => e.IdFactura)
                    .HasName("idFactura")
                    .IsUnique();

                entity.HasOne(d => d._Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Venta_ibfk_2");

                entity.HasOne(d => d._Empleado)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Venta_ibfk_3");

                entity.HasOne(d => d._Factura)
                    .WithOne(p => p.Venta)
                    .HasForeignKey<Venta>(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Venta_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
