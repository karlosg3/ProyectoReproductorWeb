using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class ListaConfiguracion : IEntityTypeConfiguration<Lista>
{
    public void Configure(EntityTypeBuilder<Lista> constructor)
    {
        constructor.HasKey(u => u.Id);
        
        constructor
            .HasMany(l => l.Tarjetas)
            .WithOne(b => b.Lista)
            .HasForeignKey(l => l.IdLista)
            .OnDelete(DeleteBehavior.Cascade);
    }
}