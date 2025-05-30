using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  Api.Persistencia.Configuraciones
{
    public class PlaylistConfiguracion
    {
        public void Configure(EntityTypeBuilder<Playlist> constructor)
    }
}