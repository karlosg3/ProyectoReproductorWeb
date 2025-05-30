using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class SeguimientoConfiguracion
    {
        public void Configure(EntityTypeBuilder<Seguimiento> constructor)
        {
            constructor.HasKey(s => new { s.UsuarioId, s.ObjetivoId });

            constructor
                .HasOne<Usuario>()
                .WithMany(s => s.Seguimientos)
                .HasForeignKey(s => s.UsuarioId);

            constructor
                .HasIndex(s => new { s.ObjetivoTipo, s.ObjetivoId });

            constructor
                .Property(s => s.ObjetivoTipo)
                .IsRequired()
                .HasMaxLength(20);

            constructor
                .Property(s => s.FechaSeguimiento)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}