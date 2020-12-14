using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWebV1.Data;
using NGWebV1.Models;

namespace NGWebV1.Controllers
{

    [Route("tipoproduto")]

    public class TipoProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<TipoProduto>>> Get(
            [FromServices] DataContext context
        )
        {
            var TipoProduto = await context
            .TipoProduto
            .AsNoTracking()
            .ToListAsync();
            return TipoProduto;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<TipoProduto>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var TipoProduto = await context
            .TipoProduto
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return TipoProduto;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<List<TipoProduto>>> Post(
            [FromBody] TipoProduto model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.TipoProduto.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar o TipoProduto" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<ActionResult<List<TipoProduto>>> Put(
            int id,
            [FromBody] TipoProduto model,
            [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "TipoProduto não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<TipoProduto>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este TipoProduto já foi atualizado " });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar o TipoProduto" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<List<TipoProduto>>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var TipoProduto = await context.TipoProduto.FirstOrDefaultAsync(x => x.Id == id);
            if (TipoProduto == null)
                return NotFound(new { message = "TipoProduto não encontrado" });

            try
            {
                context.TipoProduto.Remove(TipoProduto);
                await context.SaveChangesAsync();
                return Ok(new { message = "TipoProduto removido" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o TipoProduto" });
            }

        }
    }
}
