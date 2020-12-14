using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWebV1.Data;
using NGWebV1.Models;

namespace NGWebV1.Controllers
{

    [Route("produtos")]

    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        

        public async Task<ActionResult<List<Produto>>> Get(
            [FromServices] DataContext context
        )
        {
            var Produto = await context
            .Produtos
            .Include(x => x.TipoProduto)
            .AsNoTracking()
            .ToListAsync();
            return Produto;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Produto>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var Produto = await context
            .Produtos
            .Include(x => x.TipoProduto)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return Produto;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<List<Produto>>> Post(
            [FromBody] Produto model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar o Produto" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Produto>>> Put(
            int id,
            [FromBody] Produto model,
            [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Produto não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Produto>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este Produto já foi atualizado " });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar o Produto" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Produto>>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var Produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (Produto == null)
                return NotFound(new { message = "Produto não encontrado" });

            try
            {
                context.Produtos.Remove(Produto);
                await context.SaveChangesAsync();
                return Ok(new { message = "Produto removido" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o Produto" });
            }

        }
    }
}
