using Api.Comun.Interfaces;
using Api.Comun.Modelos.AlbumArtista;
using Api.Comun.Modelos.AlbumGenero;
using Api.Entidades;
using Api.Persistencia.Configuraciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace Api.Persistencia;

public class AplicacionBdContexto : DbContext, IAplicacionBdContexto
{
    private IDbContextTransaction _actualTransaccion;
    public AplicacionBdContexto(DbContextOptions opciones) : base(opciones)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<SesionUsuario> SesionesUsuario { get; set; }
<<<<<<< Updated upstream
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<AlbumArtista> AlbumArtistas { get; set; }
    public DbSet<AlbumGenero> AlbumGeneros { get; set; }

    public DbSet<Cancion> Canciones { get; set; }

=======
    public DbSet<Album> Albums { get; set; }/*Apaez*/
    public DbSet<GeneroMusical> GenerosMusicales { get; set; }/*Andres*/
>>>>>>> Stashed changes
    public override async Task<int> SaveChangesAsync(CancellationToken cancelacionToken = default)
    {
        foreach (var entrada in ChangeTracker.Entries<ISlug>())
        {
            if (entrada.State == EntityState.Added || entrada.State == EntityState.Modified)
            {
                var entidad = entrada.Entity;
                if (string.IsNullOrWhiteSpace(entidad.Slug))
                {
                    entidad.Slug = entidad.ObtenerDescripcionParaSlug().ToLower().Replace(" ", "-");
                }
            }
        }

        var resultado = await base.SaveChangesAsync(cancelacionToken);
        return resultado;
    }

    public async Task EmpezarTransaccionAsync()
    {
        if (_actualTransaccion != null)
        {
            return;
        }

        _actualTransaccion = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted)
            .ConfigureAwait(false);
    }

    public async Task MandarTransaccionAsync()
    {
        try
        {
            await SaveChangesAsync().ConfigureAwait(false);

            _actualTransaccion?.Commit();
        }
        catch
        {
            CancelarTransaccion();
            throw;
        }
        finally
        {
            if (_actualTransaccion != null)
            {
                _actualTransaccion.Dispose();
                _actualTransaccion = null;
            }
        }
    }

    public void CancelarTransaccion()
    {
        try
        {
            _actualTransaccion?.Rollback();
        }
        finally
        {
            if (_actualTransaccion != null)
            {
                _actualTransaccion.Dispose();
                _actualTransaccion = null;
            }
        }
    }

    public async Task<int> ExecutarSqlComandoAsync(string comandoSql, CancellationToken cancelacionToken)
    {
        return await base.Database.ExecuteSqlRawAsync(comandoSql, cancelacionToken);
    }

    public async Task<int> ExecutarSqlComandoAsync(string comandoSql, IEnumerable<object> parametros, CancellationToken cancelacionToken)
    {
        return await base.Database.ExecuteSqlRawAsync(comandoSql, parametros, cancelacionToken);
    }

    protected override void OnModelCreating(ModelBuilder constructor)
    {
        constructor.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(constructor);
    }
}
