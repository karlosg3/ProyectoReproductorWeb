using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class CancionesCondifugracion
    {
        public void Configure(EntityTypeBuilder<Cancion> constructor)
        {
            constructor.HasKey(a => a.Id);

            constructor
                .HasOne(a => a.Artista)
                .WithMany(ar => ar.Canciones)
                 .HasForeignKey(a => a.IdArtista);

            constructor
                .HasOne(a => a.Album)
                .WithMany (a => a.Canciones)
                .HasForeignKey(a => a.IdAlbum);
        }

    }
}
