using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class UsuarioConfiguracion
{
    public void Configure(EntityTypeBuilder<Usuario> constructor)
    {
        constructor.HasKey(u => u.Id);
        //El usuario puede tener varias sesiones activas
        constructor
            .HasMany<SesionUsuario>()
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.UsuarioId);
        //El usuario puede seguir a varias artistas, playlists o usuaruios?
        constructor
            .HasMany<Seguimiento>()
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.UsuarioId);

    }

}