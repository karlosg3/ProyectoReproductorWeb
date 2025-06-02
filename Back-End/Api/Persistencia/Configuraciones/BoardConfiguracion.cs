using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones;

public class BoardConfiguracion :  IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> constructor)
    {
        constructor.HasKey(u => u.Id);
        
        constructor
            .HasMany(b => b.Listas)
            .WithOne(l => l.Board)
            .HasForeignKey(l => l.IdBoard)
            .OnDelete(DeleteBehavior.Cascade);
    }
}