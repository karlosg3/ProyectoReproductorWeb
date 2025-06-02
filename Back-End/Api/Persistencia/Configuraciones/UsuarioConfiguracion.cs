using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> constructor)
    {
        constructor.HasKey(u => u.Id);
        
        constructor
            .HasMany(u => u.Sesiones)
            .WithOne(s => s.Usuario)
            .HasForeignKey(ut => ut.IdUsuario);
    }

}