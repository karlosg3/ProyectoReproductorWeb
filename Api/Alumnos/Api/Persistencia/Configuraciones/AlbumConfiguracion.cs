using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class AlbumConfiguracion
    {
        public void Configure(EntityTypeBuilder<Album> constructor)
        {
            constructor.HasKey(u => u.Id);
            constructor.HasMany(x => x.Artista)
                .WithMany(p => p.);
            constructor.HasMany(g => g.Genero)
                .WithMany(h => h.);
        }
    }
}
