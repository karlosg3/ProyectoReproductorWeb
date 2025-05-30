using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class PlaylistConfiguracion
    {
        public void Configure(EntityTypeBuilder<Playlist> constructor)
        {
            constructor.HasKey(p => p.Id);

            constructor
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.IdUsuario);
        }
    }
}