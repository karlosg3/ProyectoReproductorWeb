using Api.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.Comun.Interfaces;

public interface IAplicacionBdContexto
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<SesionUsuario> SesionesUsuario { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Cancion> Canciones { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<CancionPlaylist> CancionesPlaylist { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancelacionToken);
    int SaveChanges();
    Task<int> ExecutarSqlComandoAsync(string comandoSql, CancellationToken cancelacionToken);
    Task<int> ExecutarSqlComandoAsync(string comandoSql, IEnumerable<object> parametros, CancellationToken cancelacionToken);
    Task EmpezarTransaccionAsync();
    Task MandarTransaccionAsync();
    void CancelarTransaccion();

}