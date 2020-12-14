using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWebV1.Data;
using NGWebV1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using NGWebV1.Services;

namespace NGWebV1.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]

        public async Task<ActionResult<List<User>>> Get(
            [FromServices] DataContext context
        )
        {
            var users = await context
            .Users
            .AsNoTracking()
            .ToListAsync();
            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]

        public async Task<ActionResult<User>> GetById(
            int id,
            [FromServices] DataContext context)
        {
            var users = await context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return users;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]

        public async Task<ActionResult<List<User>>> Post(
            [FromBody] User model,
            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar o Usuário" });
            }
        }

        [HttpPost]
        [Route("login")]

        public async Task<ActionResult<dynamic>> Authenticate(
            [FromBody] User model,
            [FromServices] DataContext context)
        {
            var user = await context.Users
            .AsNoTracking()
            .Where(x => x.UserName == model.UserName && x.Password == model.Password)
            .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new {message = "Usuário ou senha inválido"});

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user,
                token = token
            };

        }

        [HttpPut]
        [Route("{id:int}")]
        [AllowAnonymous]

        public async Task<ActionResult<List<User>>> Put(
            int id,
            [FromBody] User model,
            [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Usuário não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<User>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este Usuário já foi atualizado " });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar o Usuário" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [AllowAnonymous]

        public async Task<ActionResult<List<User>>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound(new { message = "User não encontrada" });

            try
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return Ok(new { message = "User removida" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o Usuário" });
            }

        }

        
    }
}