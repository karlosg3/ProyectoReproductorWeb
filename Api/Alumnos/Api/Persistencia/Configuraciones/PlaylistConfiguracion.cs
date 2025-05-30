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
                .HasOne(u => u.Usuario)
                .WithMany(p => p.Playlists)
                .HasForeignKey(u => u.UsuarioId);
        }
    }
}