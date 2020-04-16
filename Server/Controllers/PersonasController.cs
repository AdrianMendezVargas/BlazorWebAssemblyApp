using BlazorWebAssemblyApp.Server.DAL;
using BlazorWebAssemblyApp.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Server.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase{

        private readonly Contexto contexto;

        
        public PersonasController(Contexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetPersonas() {
            return await contexto.Personas.ToListAsync();
        }

    }
}
