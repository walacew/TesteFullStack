using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.Domain.Model;
using FullStack.Repository.Interface;
using FullStackGol.Repository.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackGol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemController : Controller
    {
        public readonly IFullstackRepository _repo;
        public PassagemController(IFullstackRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var retorno =  await _repo.GetAllPassagemAsync();

                return Ok(retorno);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }           
        }

        [HttpGet("{PassagemId}")]
        public async Task<ActionResult> Get(int PassagemId)
        {
            try
            {
                var retorno =  await _repo.GetAllPassagemAsyncId(PassagemId);
                return Ok(retorno);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }    
           
        }

        [HttpPost]
        public async Task<ActionResult> Post(Passagem model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) { return Created($"/api/passagem/{model.PassagemId}", model); }

                var retorno = await _repo.GetAllPassagemAsync();

                return Ok(retorno);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPut("{PassagemId}")]
        public async Task<ActionResult> Put(int PassagemId, Passagem model)
        {
            try
            {
                if ((await _repo.GetAllPassagemAsyncId(PassagemId)).Equals(null)) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync()) { return Created($"/api/passagem/{model.PassagemId}", model); }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{PassagemId}")]
        public async Task<ActionResult> Delete(int PassagemId, Passagem model)
        {
            try
            {
                var passagem = await _repo.GetAllPassagemAsyncId(PassagemId);

                if (passagem.Equals(null)) return NotFound();

                _repo.Delete(passagem);

                if (await _repo.SaveChangesAsync()) return Ok(); 
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }

    }
}