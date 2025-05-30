using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class ArtistaConfiguracion : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artistas");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Imagen).HasMaxLength(255);
            builder.Property(a => a.Descripcion).HasMaxLength(500);
            builder.Property(a => a.Slug).IsRequired().HasMaxLength(120);
            builder.Property(a => a.Habilitado).HasDefaultValue(true);

        }
    }
}
