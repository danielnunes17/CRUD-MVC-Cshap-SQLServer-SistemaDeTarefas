using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas
{
    public class SistemasTarefasDbContext : DbContext
    {
        public SistemasTarefasDbContext(DbContextOptions<SistemasTarefasDbContext> options)
            : base(options)
        { }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}