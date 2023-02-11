using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int Id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int Id);
        Task<bool> APagar(int Id);

    }
}
