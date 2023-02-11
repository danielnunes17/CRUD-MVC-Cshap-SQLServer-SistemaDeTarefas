using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemasTarefasDbContext _sistemasTarefasDbContext;
        public UsuarioRepository(SistemasTarefasDbContext sistemasTarefasDbContext)
        {
            _sistemasTarefasDbContext = sistemasTarefasDbContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int Id)
        {
            return await _sistemasTarefasDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _sistemasTarefasDbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _sistemasTarefasDbContext.Usuarios.AddAsync(usuario);
            await _sistemasTarefasDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);
            if (usuarioPorId == null)
            {
                throw new Exception($"O usuário para o ID: {Id} não foi encontrado no banco de dados");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _sistemasTarefasDbContext.Usuarios.Update(usuarioPorId);
            await _sistemasTarefasDbContext.SaveChangesAsync();
            return usuarioPorId;
        }

        public async Task<bool> APagar(int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);
            if (usuarioPorId == null)
            {
                throw new Exception($"O usuário para o ID: {Id} não foi encontrado no banco de dados");
            }
            _sistemasTarefasDbContext.Remove(usuarioPorId);
            await _sistemasTarefasDbContext.SaveChangesAsync();
            return true;

        }
    }
}
