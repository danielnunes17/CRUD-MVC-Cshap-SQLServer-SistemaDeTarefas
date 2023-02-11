using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarioList = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(usuarioList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int Id)
        {
            UsuarioModel usuarioList = await _usuarioRepository.BuscarPorId(Id);
            return Ok(usuarioList);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepository.Adicionar(usuarioModel);
            return Ok(usuario);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int Id)
        {
            UsuarioModel usuario = await _usuarioRepository.Atualizar(usuarioModel, Id);
            return Ok(usuario);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int Id)
        {
            bool apagado = await _usuarioRepository.APagar(Id);
            return Ok(apagado);
        }
    }
}
