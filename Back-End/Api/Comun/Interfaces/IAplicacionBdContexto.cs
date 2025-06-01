using Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.Comun.Interfaces;

public interface IAplicacionBdContexto
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<SesionUsuario> SesionesUsuario { get; set; }
    public DbSet<Tarjeta> Tarjetas { get; set; }
    public DbSet<UsuarioTarjeta> UsuarioTarjetas { get; set; }
    public DbSet<Lista> Listas { get; set; }
    public DbSet<Board> Boards { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancelacionToken);
    int SaveChanges();
    Task<int> ExecutarSqlComandoAsync(string comandoSql, CancellationToken cancelacionToken);
    Task<int> ExecutarSqlComandoAsync(string comandoSql, IEnumerable<object> parametros, CancellationToken cancelacionToken);
    Task EmpezarTransaccionAsync();
    Task MandarTransaccionAsync();
    void CancelarTransaccion();

}