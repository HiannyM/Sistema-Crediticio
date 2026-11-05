using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SNIC_RD.Models;
  
namespace SNIC_RD.Models;

public partial class SnicRdContext : DbContext
{
    public SnicRdContext()
    {
    }

    public SnicRdContext(DbContextOptions<SnicRdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BitacoraAuditorium> BitacoraAuditoria { get; set; }

    public virtual DbSet<Consentimiento> Consentimientos { get; set; }

    public virtual DbSet<ConsultaCredito> ConsultaCreditos { get; set; }

    public virtual DbSet<EntidadReportante> EntidadReportantes { get; set; }

    public virtual DbSet<EvidenciaReclamacion> EvidenciaReclamacions { get; set; }

    public virtual DbSet<HistorialAnualPago> HistorialAnualPagos { get; set; }

    public virtual DbSet<HistorialCrediticio> HistorialCrediticios { get; set; }

    public virtual DbSet<LoteCarga> LoteCargas { get; set; }

    public virtual DbSet<Notificacion> Notificacions { get; set; }

    public virtual DbSet<OperacionCredito> OperacionCreditos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<ProveedorAlternativo> ProveedorAlternativos { get; set; }

    public virtual DbSet<PuntajeCrediticio> PuntajeCrediticios { get; set; }

    public virtual DbSet<Reclamacion> Reclamacions { get; set; }

    public virtual DbSet<RegistroCarga> RegistroCargas { get; set; }

    public virtual DbSet<RegistroPagoAlternativo> RegistroPagoAlternativos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Titular> Titulars { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=SNIC_RD;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BitacoraAuditorium>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK__Bitacora__7E4268B089E64C08");

            entity.Property(e => e.IdBitacora).HasColumnName("id_bitacora");
            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("accion");
            entity.Property(e => e.DireccionIp)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("direccion_ip");
            entity.Property(e => e.FechaAccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_accion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.RegistroId).HasColumnName("registro_id");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tabla_afectada");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.BitacoraAuditoria)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__BitacoraA__id_us__04E4BC85");
        });

        modelBuilder.Entity<Consentimiento>(entity =>
        {
            entity.HasKey(e => e.IdConsentimiento).HasName("PK__Consenti__72A2630E7115D95B");

            entity.ToTable("Consentimiento");

            entity.Property(e => e.IdConsentimiento).HasColumnName("id_consentimiento");
            entity.Property(e => e.EstadoConsentimiento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Activo")
                .HasColumnName("estado_consentimiento");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.FechaOtorgamiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_otorgamiento");
            entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");
            entity.Property(e => e.IdTitular).HasColumnName("id_titular");
            entity.Property(e => e.Proposito)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("proposito");

            entity.HasOne(d => d.IdEntidadNavigation).WithMany(p => p.Consentimientos)
                .HasForeignKey(d => d.IdEntidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consentim__id_en__0A9D95DB");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.Consentimientos)
                .HasForeignKey(d => d.IdTitular)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consentim__id_ti__09A971A2");
        });

        modelBuilder.Entity<ConsultaCredito>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__6F53588B07E4A9E9");

            entity.ToTable("ConsultaCredito");

            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.FechaConsulta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_consulta");
            entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");
            entity.Property(e => e.IdTitular).HasColumnName("id_titular");
            entity.Property(e => e.Proposito)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("proposito");

            entity.HasOne(d => d.IdEntidadNavigation).WithMany(p => p.ConsultaCreditos)
                .HasForeignKey(d => d.IdEntidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ConsultaC__id_en__693CA210");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.ConsultaCreditos)
                .HasForeignKey(d => d.IdTitular)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ConsultaC__id_ti__68487DD7");
        });

        modelBuilder.Entity<EntidadReportante>(entity =>
        {
            entity.HasKey(e => e.IdEntidad).HasName("PK__EntidadR__939AFD257DB7D0F5");

            entity.ToTable("EntidadReportante");

            entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Activo")
                .HasColumnName("estado");
            entity.Property(e => e.NombreEntidad)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_entidad");
            entity.Property(e => e.RncEntidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rnc_entidad");
            entity.Property(e => e.TipoEntidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_entidad");
        });

        modelBuilder.Entity<EvidenciaReclamacion>(entity =>
        {
            entity.HasKey(e => e.IdEvidencia).HasName("PK__Evidenci__62875FB91138FE9C");

            entity.ToTable("EvidenciaReclamacion");

            entity.Property(e => e.IdEvidencia).HasColumnName("id_evidencia");
            entity.Property(e => e.FechaSubida)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_subida");
            entity.Property(e => e.IdReclamacion).HasColumnName("id_reclamacion");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_archivo");
            entity.Property(e => e.RutaAlmacenamiento)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ruta_almacenamiento");

            entity.HasOne(d => d.IdReclamacionNavigation).WithMany(p => p.EvidenciaReclamacions)
                .HasForeignKey(d => d.IdReclamacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evidencia__id_re__76969D2E");
        });

        modelBuilder.Entity<HistorialAnualPago>(entity =>
        {
            entity.HasKey(e => e.IdHistorialAnual).HasName("PK__Historia__C0A6DB07AF6856F8");

            entity.Property(e => e.IdHistorialAnual).HasColumnName("id_historial_anual");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");
            entity.Property(e => e.MontoMaximoMora)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_maximo_mora");
            entity.Property(e => e.TotalAtrasos)
                .HasDefaultValue(0)
                .HasColumnName("total_atrasos");
            entity.Property(e => e.TotalPagado)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_pagado");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.HistorialAnualPagos)
                .HasForeignKey(d => d.IdOperacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__id_op__60A75C0F");
        });

        modelBuilder.Entity<HistorialCrediticio>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__76E6C5023C1D4305");

            entity.ToTable("HistorialCrediticio");

            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.DiasMora)
                .HasDefaultValue(0)
                .HasColumnName("dias_mora");
            entity.Property(e => e.EstadoCuota)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_cuota");
            entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");
            entity.Property(e => e.MesReporte).HasColumnName("mes_reporte");
            entity.Property(e => e.MontoCuota)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_cuota");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.HistorialCrediticios)
                .HasForeignKey(d => d.IdOperacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__id_op__5AEE82B9");
        });

        modelBuilder.Entity<LoteCarga>(entity =>
        {
            entity.HasKey(e => e.IdLote).HasName("PK__LoteCarg__9A00048693EE25CF");

            entity.ToTable("LoteCarga");

            entity.Property(e => e.IdLote).HasColumnName("id_lote");
            entity.Property(e => e.EstadoLote)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_lote");
            entity.Property(e => e.FechaCarga)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_carga");
            entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_archivo");
            entity.Property(e => e.RegistrosExitosos).HasColumnName("registros_exitosos");
            entity.Property(e => e.RegistrosRechazados).HasColumnName("registros_rechazados");
            entity.Property(e => e.TotalRegistros).HasColumnName("total_registros");

            entity.HasOne(d => d.IdEntidadNavigation).WithMany(p => p.LoteCargas)
                .HasForeignKey(d => d.IdEntidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoteCarga__id_en__0E6E26BF");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__8270F9A5B0966CAE");

            entity.ToTable("Notificacion");

            entity.Property(e => e.IdNotificacion).HasColumnName("id_notificacion");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.IdTitular).HasColumnName("id_titular");
            entity.Property(e => e.Leido)
                .HasDefaultValue(false)
                .HasColumnName("leido");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");
            entity.Property(e => e.TipoNotificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_notificacion");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.IdTitular)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__id_ti__01142BA1");
        });

        modelBuilder.Entity<OperacionCredito>(entity =>
        {
            entity.HasKey(e => e.IdOperacion).HasName("PK__Operacio__AC60F4261402DB78");

            entity.ToTable("OperacionCredito");

            entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");
            entity.Property(e => e.BalanceActual)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("balance_actual");
            entity.Property(e => e.EstadoOperacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_operacion");
            entity.Property(e => e.FechaOtorgamiento).HasColumnName("fecha_otorgamiento");
            entity.Property(e => e.FechaUltimoPago).HasColumnName("fecha_ultimo_pago");
            entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");
            entity.Property(e => e.IdTitular).HasColumnName("id_titular");
            entity.Property(e => e.MontoOriginal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_original");
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_producto");

            entity.HasOne(d => d.IdEntidadNavigation).WithMany(p => p.OperacionCreditos)
                .HasForeignKey(d => d.IdEntidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operacion__id_en__571DF1D5");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.OperacionCreditos)
                .HasForeignKey(d => d.IdTitular)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operacion__id_ti__5629CD9C");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pago__0941B0746133C317");

            entity.ToTable("Pago");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.CanalPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("canal_pago");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");
            entity.Property(e => e.MontoPagado)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_pagado");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdOperacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pago__id_operaci__6477ECF3");
        });

        modelBuilder.Entity<ProveedorAlternativo>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__8D3DFE28DAD77A1B");

            entity.ToTable("ProveedorAlternativo");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_proveedor");
            entity.Property(e => e.RncProveedor)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("rnc_proveedor");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_servicio");
        });

        modelBuilder.Entity<PuntajeCrediticio>(entity =>
        {
            entity.HasKey(e => e.IdPuntaje).HasName("PK__PuntajeC__FEF9A3611874E61A");

            entity.ToTable("PuntajeCrediticio");

            entity.Property(e => e.IdPuntaje).HasColumnName("id_puntaje");
            entity.Property(e => e.FechaCalculo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_calculo");
            entity.Property(e => e.IdTitular).HasColumnName("id_titular");
            entity.Property(e => e.Puntaje).HasColumnName("puntaje");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.PuntajeCrediticios)
                .HasForeignKey(d => d.IdTitular)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PuntajeCr__id_ti__6D0D32F4");
        });

        modelBuilder.Entity<Reclamacion>(entity =>
        {
            entity.HasKey(e => e.IdReclamacion).HasName("PK__Reclamac__036DB9A57BBA54B8");

            entity.ToTable("Reclamacion");

            entity.Property(e => e.IdReclamacion).HasColumnName("id_reclamacion");
            entity.Property(e => e.DescripcionReclamo)
                .HasColumnType("text")
                .HasColumnName("descripcion_reclamo");
            entity.Property(e => e.EstadoReclamo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado_reclamo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaLimiteRespuesta).HasColumnName("fecha_limite_respuesta");
            entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");
            entity.Property(e => e.IdTitular).HasColumnName("id_titular");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.Reclamacions)
                .HasForeignKey(d => d.IdOperacion)
                .HasConstraintName("FK__Reclamaci__id_op__72C60C4A");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.Reclamacions)
                .HasForeignKey(d => d.IdTitular)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reclamaci__id_ti__71D1E811");
        });

        modelBuilder.Entity<RegistroCarga>(entity =>
        {
            entity.HasKey(e => e.IdRegistroCarga).HasName("PK__Registro__0EF2500A5BBF275D");

            entity.ToTable("RegistroCarga");

            entity.Property(e => e.IdRegistroCarga).HasColumnName("id_registro_carga");
            entity.Property(e => e.DetalleFila)
                .HasColumnType("text")
                .HasColumnName("detalle_fila");
            entity.Property(e => e.IdLote).HasColumnName("id_lote");
            entity.Property(e => e.MensajeError)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("mensaje_error");
            entity.Property(e => e.Resultado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("resultado");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.RegistroCargas)
                .HasForeignKey(d => d.IdLote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistroC__id_lo__114A936A");
        });

        modelBuilder.Entity<RegistroPagoAlternativo>(entity =>
        {
            entity.HasKey(e => e.IdPagoAlternativo).HasName("PK__Registro__2CD5EBCBBCC7D30B");

            entity.ToTable("RegistroPagoAlternativo");

            entity.Property(e => e.IdPagoAlternativo).HasColumnName("id_pago_alternativo");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_pago");
            entity.Property(e => e.FechaFacturacion).HasColumnName("fecha_facturacion");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdTitular).HasColumnName("id_titular");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.RegistroPagoAlternativos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistroP__id_pr__7C4F7684");

            entity.HasOne(d => d.IdTitularNavigation).WithMany(p => p.RegistroPagoAlternativos)
                .HasForeignKey(d => d.IdTitular)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistroP__id_ti__7B5B524B");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__6ABCB5E02A0DF92D");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Titular>(entity =>
        {
            entity.HasKey(e => e.IdTitular).HasName("PK__Titular__4E1CC016CFE77E75");

            entity.ToTable("Titular");

            entity.Property(e => e.IdTitular).HasColumnName("id_titular");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.Rnc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rnc");
            entity.Property(e => e.TelefonoCasa)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_casa");
            entity.Property(e => e.TelefonoMovil)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_movil");
            entity.Property(e => e.TelefonoOficina)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_oficina");
            entity.Property(e => e.TipoTitular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_titular");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__4E3E04ADECEEA4C6");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__id_rol__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
