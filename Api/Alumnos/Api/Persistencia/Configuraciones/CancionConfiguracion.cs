using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class CancionConfiguracion
    {
        public void Configure(EntityTypeBuilder<Cancion> constructor)
        {
            constructor.HasKey(a => a.Id);

            constructor
                .HasMany(a => a.CancionArtistas)
                .WithOne(ar => ar.Cancion)
                 .HasForeignKey(a => a.Id);
        }

    }
}
