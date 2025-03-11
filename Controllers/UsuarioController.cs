using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para Cadastrar o usuario
        /// </summary>
        /// <param name="usuario">id do usuario listado</param>
        /// <returns>Usuario listado</returns>
        [Authorize]
        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201, usuario);

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para Buscar por id
        /// </summary>
        /// <param name="id">id do usuario buscado</param>
        /// <returns>id do usuario</returns>
        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                if (usuario != null)
                {

                    return Ok(usuario);
                }
                return null!;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet("BuscarPorEmailESenha")]

        //public IActionResult GetByEmailAndSenha(string email, string senha)
        //{
        //    try
        //    {
        //        Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);
                
        //        if (usuarioBuscado != null)
        //        { 
        //            return Ok(usuarioBuscado);
        //        }
        //        return null!;
        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest(e.Message);
        //    }
        //}




    }
}
