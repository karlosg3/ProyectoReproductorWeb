using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class UsuarioTarjetaConfiguracion
{
    public void Configure(EntityTypeBuilder<UsuarioTarjeta> constructor)
    {
        constructor
            .HasKey(ut => new { ut.IdUsuario, ut.IdTarjeta });

        constructor
            .HasOne(ut => ut.Usuario)
            .WithMany(u => u.UsuarioTarjetas)
            .HasForeignKey(ut => ut.IdUsuario);

        constructor
            .HasOne(ut => ut.Tarjeta)
            .WithMany(t => t.UsuarioTarjetas)
            .HasForeignKey(ut => ut.IdTarjeta);
    }

}