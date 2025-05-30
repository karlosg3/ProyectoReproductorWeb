using Api.Comun.Interfaces;
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
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Cancion> Canciones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<CancionPlaylist> CancionPlaylists { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Seguimiento> Seguimientos { get; set; }
    public DbSet<Colaboracion> Colaboraciones { get; set; }
    public DbSet<SesionUsuario> SesionesUsuario { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DbSet<GeneroMusical> GenerosMusicales { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public AplicacionBdContexto(DbContextOptions<DbContext> options)
        : base(options)
    {
    }


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
        constructor.Entity<CancionPlaylist>()
            .HasKey(cp => new { cp.PlaylistId, cp.CancionId });

        constructor.Entity<Colaboracion>()
            .HasKey(c => new { c.CancionId, c.ArtistaId });

        // Configuraciones adicionales según sea necesario

        base.OnModelCreating(constructor);
    }
}
