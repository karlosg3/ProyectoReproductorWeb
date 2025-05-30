using System.Runtime.CompilerServices;
using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class CancionPlaylistConfiguracion
    {
        public void Configure(EntityTypeBuilder<CancionPlaylist> constructor)
        {
            constructor.HasKey(cp => new { cp.CancionId, cp.PlaylistId });
            constructor
                .HasOne(c => c.Cancion)
                .WithMany(cp => cp.CancionPlaylists)
                .HasForeignKey(c => c.CancionId);

            constructor
                .HasOne(p => p.Playlist)
                .WithMany(cp => cp.CancionPlaylists)
                .HasForeignKey(p => p.PlaylistId);
        }
    }
}