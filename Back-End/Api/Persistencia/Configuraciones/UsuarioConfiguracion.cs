using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class UsuarioConfiguracion
{
    public void Configure(EntityTypeBuilder<Usuario> constructor)
    {
        constructor.HasKey(u => u.Id);
        
        constructor
            .HasMany(u => u.UsuarioTarjetas)
            .WithOne(ut => ut.Usuario)
            .HasForeignKey(ut => ut.UsuarioId);
    }

}