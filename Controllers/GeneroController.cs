using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMovie.API.DTOs;
using PMovie.DAL;

namespace PMovie.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : Controller
    {
        private readonly PeliculasContext PeliculasContext;

        public GeneroController(PeliculasContext PeliculasContext)
        {
            this.PeliculasContext = PeliculasContext;
        }


        [HttpGet("GetGeneros")]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            var List = await PeliculasContext.Genero.Select(
                s => new GeneroDTO
                {
                    IdGenero = s.IdGenero,
                    Nombre = s.Nombre
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
    }
}
