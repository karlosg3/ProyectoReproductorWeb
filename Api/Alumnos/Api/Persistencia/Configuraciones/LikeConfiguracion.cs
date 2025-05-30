using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistencia.Configuraciones
{
    public class LikeConfiguracion
    {
        public void Configure(EntityTypeBuilder<Like> constructor)
        {
            constructor.HasKey(l => new { l.UsuarioId, l.CancionId });
            
            constructor
                .HasOne(u => u.Usuario)
                .WithMany(l => l.Likes)
                .HasForeignKey(u => u.UsuarioId);

            constructor
                .HasOne(c => c.Cancion)
                .WithMany(l => l.Likes)
                .HasForeignKey(c => c.CancionId);
        }
    }
}