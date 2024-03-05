using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace API_institucion.Models.DB
{
    /// <summary>
    /// Representa el contexto de la base de datos para la aplicación del colegio.
    /// </summary>
    public partial class InstitutoContext : DbContext
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase ColegioContext sin opciones de contexto.
        /// Esta instancia se utiliza cuando se crea un nuevo contexto sin necesidad de configuración.
        /// </summary>
        public InstitutoContext()
        {
        }

        /// Inicializa una nueva instancia de la clase ColegioContext con opciones de contexto proporcionadas.
        /// Esta instancia se utiliza cuando se configura el contexto a través de la inyección de dependencias.
        /// </summary>
        /// <param name="options">Opciones de contexto proporcionadas para configurar la conexión a la base de datos.</param>
        public InstitutoContext(DbContextOptions<InstitutoContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Obtiene o establece el conjunto de entidades para los estudiantes en la base de datos.
        /// </summary>
        public virtual DbSet<Estudent> Estudents { get; set; }

        public virtual DbSet<Cursos> Courses { get; set; }
        /// Configura el modelo de la base de datos durante la creación del contexto.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo que se utiliza para configurar las entidades y propiedades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudent>(entity =>
            {
                // Configuración de la entidad Estudiante
                entity.HasKey(e => e.Estu_id).HasName("PK__Estudian__3214EC0739BC17BD");

                entity.Property(e => e.Estu_surname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estu_name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                // Configuración de la entidad cursos
                entity.HasKey(e => e.Cour_id).HasName("PK__Course__1234EC0739BC17BD");

                entity.Property(e => e.Cour_name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cour_description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            // Invoca cualquier lógica adicional de configuración definida en la parte parcial de OnModelCreatingPartial
            OnModelCreatingPartial(modelBuilder);
        }

        /// Método parcial para proporcionar lógica adicional de configuración del modelo.
        /// Este método puede ser implementado en otra parte parcial de la clase si es necesario.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo que se utiliza para configurar las entidades y propiedades.</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
