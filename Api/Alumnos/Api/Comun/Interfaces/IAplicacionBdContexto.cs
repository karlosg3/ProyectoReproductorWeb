using Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.Comun.Interfaces;

public interface IAplicacionBdContexto
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<SesionUsuario> SesionesUsuario { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<GeneroMusical> GenerosMusicales { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancelacionToken);
    int SaveChanges();
    Task<int> ExecutarSqlComandoAsync(string comandoSql, CancellationToken cancelacionToken);
    Task<int> ExecutarSqlComandoAsync(string comandoSql, IEnumerable<object> parametros, CancellationToken cancelacionToken);
    Task EmpezarTransaccionAsync();
    Task MandarTransaccionAsync();
    void CancelarTransaccion();

}