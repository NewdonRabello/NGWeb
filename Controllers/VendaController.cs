using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWebV1.Data;
using NGWebV1.Models;

namespace NGWebV1.Controllers
{

    [Route("vendas")]

    public class VendaController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Venda>>> Get(
            [FromServices] DataContext context
        )
        {
            var Vendas = await context
            .Vendas
            .Include(x => x.VendaProduto)
            .Include(x => x.Cliente)
            .AsNoTracking()
            .ToListAsync();
            return Vendas;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Venda>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var Venda = await context
            .Vendas
            .Include(x => x.VendaProduto)
            .Include(x => x.Cliente)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return Venda;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<List<Venda>>> Post(
            [FromBody] Venda model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Vendas.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar o Venda" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Venda>>> Put(
            int id,
            [FromBody] Venda model,
            [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Venda não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Venda>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este Venda já foi atualizado " });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar o Venda" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Venda>>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var Venda = await context.Vendas.FirstOrDefaultAsync(x => x.Id == id);
            if (Venda == null)
                return NotFound(new { message = "Venda não encontrado" });

            try
            {
                context.Vendas.Remove(Venda);
                await context.SaveChangesAsync();
                return Ok(new { message = "Venda removido" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o Venda" });
            }

        }

    }
}