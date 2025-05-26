using Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Api.Persistencia.Configuraciones
{
    public class GenerosMusicalesConfiguration
    {
        public void Configure(EntityTypeBuilder<GeneroMusical> constructor)
        {
            constructor.HasKey(identificador => identificador.Id);
            constructor.Property(name => name.Nombre)
                .IsRequired()/*Que no sea null*/
                .HasMaxLength(100);
           
        }
    }
}
