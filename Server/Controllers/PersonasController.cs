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
    public class PersonasController : ControllerBase {

        private readonly Contexto contexto;


        public PersonasController(Contexto contexto) {
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get() {
            return await contexto.Personas.ToListAsync();
        }

        [HttpGet("{PersonaId}" , Name = "obtenerPersona")]
        public async Task<ActionResult<Persona>> Get(int PersonaId) {
            return await contexto.Personas.FirstOrDefaultAsync(p => p.PersonaId == PersonaId);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona) {
            contexto.Add(persona);
            await contexto.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerPersona" , new { PersonaId = persona.PersonaId } , persona);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Persona persona) {
            contexto.Entry(persona).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{PersonaId}")]
        public async Task<ActionResult> Delete(int PersonaId) {

            Persona persona = new Persona { PersonaId = PersonaId };
            contexto.Remove(persona);
            await contexto.SaveChangesAsync();
            return NoContent();

        }

    }
}
