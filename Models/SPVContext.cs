using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPV.Models
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
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correoElectronico")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NoNit)
                    .IsRequired()
                    .HasColumnName("noNit")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoTelefono)
                    .IsRequired()
                    .HasColumnName("noTelefono")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("idProveedor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("idEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("idProveedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroFactura)
                    .IsRequired()
                    .HasColumnName("numeroFactura")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PrecioTotal)
                    .HasColumnName("precioTotal")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Compra_ibfk_2");

                entity.HasOne(d => d.IdProveedorNavigation)
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCompra)
                    .HasColumnName("idCompra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Iva)
                    .HasColumnName("iva")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'12'");

                entity.Property(e => e.PrecioCantidad)
                    .HasColumnName("precioCantidad")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleCompras_ibfk_1");

                entity.HasOne(d => d.IdProductoNavigation)
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVenta)
                    .HasColumnName("idVenta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrecioCantidad)
                    .HasColumnName("precioCantidad")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleVenta_ibfk_2");

                entity.HasOne(d => d.IdVentaNavigation)
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correoElectronico")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnName("fechaDeNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("date");

                entity.Property(e => e.IdGenero)
                    .HasColumnName("idGenero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NoCelular)
                    .IsRequired()
                    .HasColumnName("noCelular")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoDpi)
                    .IsRequired()
                    .HasColumnName("noDPI")
                    .HasColumnType("varchar(13)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoNit)
                    .IsRequired()
                    .HasColumnName("noNit")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoTelefono)
                    .HasColumnName("noTelefono")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'0'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Empleado_ibfk_1");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasColumnName("serie")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasColumnType("enum('Masculino','Femenimo')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Iva)
                    .HasColumnName("iva")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'12'");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdProductoNavigation)
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaDeVencimiento)
                    .HasColumnName("fechaDeVencimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("idCategoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("idProveedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Producto_ibfk_1");

                entity.HasOne(d => d.IdProveedorNavigation)
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correoElectronico")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NoNit)
                    .IsRequired()
                    .HasColumnName("noNit")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NoTelefono)
                    .IsRequired()
                    .HasColumnName("noTelefono")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RolEmpleado>(entity =>
            {
                entity.HasKey(e => new { e.IdRol, e.IdEmpleado })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("idEmpleado");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("idEmpleado")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RolEmpleado)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RolEmpleado_ibfk_1");

                entity.HasOne(d => d.IdRolNavigation)
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

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("idEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sal)
                    .IsRequired()
                    .HasColumnName("sal")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmpleadoNavigation)
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("idEmpleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFactura)
                    .HasColumnName("idFactura")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrecioTota)
                    .HasColumnName("precioTota")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Venta_ibfk_2");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Venta_ibfk_3");

                entity.HasOne(d => d.IdFacturaNavigation)
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
