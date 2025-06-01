using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class TarjetaConfiguracion
{
    public void Configure(EntityTypeBuilder<Tarjeta> constructor)
    {
        constructor.HasKey(u => u.Id);
        
        constructor
            .HasMany(t => t.UsuarioTarjetas)
            .WithOne(ut => ut.Tarjeta)
            .HasForeignKey(ut => ut.TarjetaId);
    }
}