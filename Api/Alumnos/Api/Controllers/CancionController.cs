using Api.Comun.Interfaces;
using Api.Comun.Modelos.Cancion;
using Api.Comun.Modelos.GenerosMusicales;
using Api.Comun.Modelos.Usuarios;
using Api.Comun.Utilidades;
using Api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    //[Authorize]
    [Route("canciones")]
    public class CancionController : ControllerBase
    {

        private readonly IAplicacionBdContexto _contexto;

        public CancionController (IAplicacionBdContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<List<BuscarCancionDto>> ObtenerCanciones(string titulo, bool habilitado)
        {
            var query = _contexto.Canciones.Where(x => x.Habilitado == habilitado);

            if (string.IsNullOrEmpty(titulo) == false)
            {
                query = query.Where(x => x.Titulo.Contains(titulo));
                                    
                                       
            }
            var lista = await query.ToListAsync();

            return lista.ConvertAll(x => x.ConvertirDto());
        }

        [HttpGet("{slug}")]
        public async Task<BuscarCancionDto> ObtenerCanciones(string slug, CancellationToken cancelacionToken)
        {
            var cancion = await _contexto.Canciones.FirstOrDefaultAsync(x => x.Slug == slug, cancelacionToken);

            if (cancion == null)
                return new BuscarCancionDto();

            return cancion.ConvertirDto();
        }


        // Crear Canción 

        [HttpPost]
        public async Task<string> CrearCancion([FromBody] CrearCancionDto cancion, CancellationToken cancelacionToken)
        {
          

            var nuevaCancion = new Cancion()
            {
                Titulo = cancion.Titulo,
                ArchivoDeAudio = cancion.ArchivoDeAudio,
                IdAlbum = cancion.IdAlbum,
                IdArtista = cancion.IdArtista,
                Portada = cancion.Portada,
                FechaDeLanzamiento = cancion.FechaDeLanzamiento,
                Habilitado = cancion.Habilitado,
            };
            await _contexto.Canciones.AddAsync(nuevaCancion, cancelacionToken);
            await _contexto.SaveChangesAsync(cancelacionToken);

            return nuevaCancion.Slug;
        }


        [HttpPatch("{slug}")]
        public async Task<bool> CambiarHabilitado([FromBody] HabilitadoCancionDto cancion,
      CancellationToken cancelacionToken)
        {
            var entidad = await _contexto.Canciones.FirstOrDefaultAsync(x => x.Slug == cancion.Slug, cancelacionToken);

            if (entidad == null)
                return false;

            entidad.Habilitado = cancion.Habilitado;

            await _contexto.SaveChangesAsync(cancelacionToken);

            return true;
        }

    }

}

    
