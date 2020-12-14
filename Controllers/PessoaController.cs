using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWebV1.Data;
using NGWebV1.Models;

namespace NGWebV1.Controllers
{

    [Route("pessoas")]

    public class PessoaController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Pessoa>>> Get(
            [FromServices] DataContext context
        )
        {
            var pessoa = await context
            .Pessoas
            .AsNoTracking()
            .ToListAsync();
            return pessoa;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Pessoa>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var pessoa = await context
            .Pessoas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return pessoa;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<List<Pessoa>>> Post(
            [FromBody] Pessoa model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Pessoas.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar a pessoa" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Pessoa>>> Put(
            int id,
            [FromBody] Pessoa model,
            [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Pessoa não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Pessoa>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Esta pessoa já foi atualizada " });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar a pessoa" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Pessoa>>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
            if (pessoa == null)
                return NotFound(new { message = "Pessoa não encontrada" });

            try
            {
                context.Pessoas.Remove(pessoa);
                await context.SaveChangesAsync();
                return Ok(new { message = "Pessoa removida" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a pessoa" });
            }

        }

        //,
        //"ConnectionStrings": {
        //  "connectionString": "server=localhost, 1433; database=NGWebV1; User ID=ngweb; Password=123456"
        //}

    }
}