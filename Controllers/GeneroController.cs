using System.Linq.Expressions;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
 
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }


        /// <summary>
        /// Endpoint para Listar seu genero
        /// </summary>
        /// <returns>Genero Listado</returns>
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Endpoint para Cadastrar seu genero
        /// </summary>
        /// <param name="novoGenero">id do genero cadastrado</param>
        /// <returns>Genero cadastrado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post (Genero novoGenero)
       {
            try
            {
                _generoRepository.Cadastrar(novoGenero);
                    return Created();

            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar um genero pelo seu id
        /// </summary>
        /// <param name="id">id do genero buscado</param>
        /// <returns>Genero Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorId(id);
                return Ok(generoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para deletar um genero
        /// </summary>
        /// <param name="id">id do genero deletado</param>
        /// <returns>Genero deletado</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Deletar(id);
                return NoContent();
            }

            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint para atualizar os generos
        /// </summary>
        /// <param name="id">id do genero atualizado</param>
        /// <param name="genero"></param>
        /// <returns>Genero atulizado</returns>
        [Authorize]
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
