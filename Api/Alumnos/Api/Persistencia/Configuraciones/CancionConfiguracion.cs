using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class CancionConfiguracion
    {
        public void Configure(EntityTypeBuilder<Cancion> constructor)
        {
            constructor.HasKey(a => a.Id);

            constructor
                .HasOne(a => a.Album)
                .WithMany(a => a.Canciones)
                .HasForeignKey(a => a.AlbumId);

            
        }

    }
}
