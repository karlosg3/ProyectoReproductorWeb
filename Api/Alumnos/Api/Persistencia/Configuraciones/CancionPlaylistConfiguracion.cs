using System.Runtime.CompilerServices;
using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class CancionPlaylistConfiguracion
    {
        public void Configure(EntityTypeBuilder<CancionPlaylist> constructor)
        {
            constructor.HasKey(cp => cp.Id);

            constructor
                .HasOne(cp => cp.Playlist)
                .WithMany(p => p.CancionPlaylists)
                .HasForeignKey(cp => cp.IdPlaylist);

            constructor
                .HasOne(cp => cp.Cancion)
                .WithMany(c => c.CancionPlaylists)
                .HasForeignKey(cp => cp.IdCancion);
        }
    }
}