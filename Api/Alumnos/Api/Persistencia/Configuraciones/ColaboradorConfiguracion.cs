using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class ColaboradorConfiguracion
    {
        public void Configure(EntityTypeBuilder<Colaboracion> constructor)
        {
            constructor.HasKey(a => new { a.CancionId, a.ArtistaId });

            constructor
                .HasOne(a => a.Cancion)
                .WithMany(ar => ar.Colaboraciones)
                .HasForeignKey(a => a.CancionId);

            constructor
                .HasOne(c => c.Artista)
                .WithMany(a => a.Colaboraciones)
                .HasForeignKey(c => c.ArtistaId);
        }
    }
}
