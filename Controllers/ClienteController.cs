using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWebV1.Data;
using NGWebV1.Models;

namespace NGWebV1.Controllers
{

    [Route("clientes")]

    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]

        public async Task<ActionResult<List<Cliente>>> Get(
            [FromServices] DataContext context
        )
        {
            var clientes = await context
            .Clientes
            .Include(x => x.Pessoa)
            .AsNoTracking()
            .ToListAsync();
            return clientes;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]

        public async Task<ActionResult<Cliente>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var cliente = await context
            .Clientes
            .Include(x => x.Pessoa)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return cliente;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]

        public async Task<ActionResult<List<Cliente>>> Post(
            [FromBody] Cliente model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar o cliente" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [AllowAnonymous]

        public async Task<ActionResult<List<Cliente>>> Put(
            int id,
            [FromBody] Cliente model,
            [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Cliente não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Cliente>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este cliente já foi atualizado " });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar o cliente" });
            }
        }
        

        [HttpDelete]
        [Route("{id:int}")]
        [AllowAnonymous]

        public async Task<ActionResult<List<Cliente>>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
                return NotFound(new { message = "Cliente não encontrado" });

            try
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cliente removido" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o cliente" });

                
            }

        }

    }
}