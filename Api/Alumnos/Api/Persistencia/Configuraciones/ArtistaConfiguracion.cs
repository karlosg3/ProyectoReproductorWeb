using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class ArtistaConfiguracion : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> constructor)
        {
            constructor.HasKey(a => a.Id);
        }
    }
}
