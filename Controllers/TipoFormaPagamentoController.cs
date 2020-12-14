using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWebV1.Data;
using NGWebV1.Models;

namespace NGWebV1.Controllers
{

    [Route("tipoformapagamento")]

    public class TipoFormaPagamentoController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<TipoFormaPagamento>>> Get(
            [FromServices] DataContext context
        )
        {
            var TipoFormaPagamento = await context
            .TipoFormaPagamento
            .AsNoTracking()
            .ToListAsync();
            return TipoFormaPagamento;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<TipoFormaPagamento>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var TipoFormaPagamento = await context
            .TipoFormaPagamento
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return TipoFormaPagamento;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<List<TipoFormaPagamento>>> Post(
            [FromBody] TipoFormaPagamento model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.TipoFormaPagamento.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar a Forma de Pagamento" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<ActionResult<List<TipoFormaPagamento>>> Put(
            int id,
            [FromBody] TipoFormaPagamento model,
            [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Forma de Pagamento não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<TipoFormaPagamento>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Esta Forma de Pagamento já foi atualizada " });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a Forma de Pagamento" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<List<TipoFormaPagamento>>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var TipoFormaPagamento = await context.TipoFormaPagamento.FirstOrDefaultAsync(x => x.Id == id);
            if (TipoFormaPagamento == null)
                return NotFound(new { message = "Forma de pagamento não encontrada" });

            try
            {
                context.TipoFormaPagamento.Remove(TipoFormaPagamento);
                await context.SaveChangesAsync();
                return Ok(new { message = "Forma de pagamento removida" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a Forma de Pagamento" });
            }

        }

    }
}