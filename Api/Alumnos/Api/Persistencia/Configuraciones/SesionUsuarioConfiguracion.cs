using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class SesionUsuarioConfiguracion
{
    public void Configure(EntityTypeBuilder<SesionUsuario> constructor)
    {
        constructor.HasKey(u => u.Id);
        constructor
            .HasOne(s => s.Usuario)
            .WithMany(su => su.SesionesUsuarios)
            .HasForeignKey(u => u.UsuarioId);
    }

}