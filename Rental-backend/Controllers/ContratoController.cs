using Mach.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mach.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ContratoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //test controller
        [HttpGet]
        public async Task<ActionResult<List<Contrato>>> Get()
        {
            return await context.Contrato.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contrato>> Get(int id)
        {
            return await context.Contrato.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Contrato contrato)
        {
            context.Contrato.Add(contrato);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Contrato contrato)
        {
            var existe = await context.Contrato.AnyAsync(x => x.Id == id);

            if (!existe)
                return NotFound("El contrato no existe");

            if (id != contrato.Id)
                return BadRequest("el id de la ruta no coincide con el del contrato enviado");
                        
            context.Contrato.Update(contrato);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Contrato.AnyAsync(x => x.Id == id);

            if (!existe)
                return NotFound("El contrato no existe");

            context.Contrato.Remove(new Contrato() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
