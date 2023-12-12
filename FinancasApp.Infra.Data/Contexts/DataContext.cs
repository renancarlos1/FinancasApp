using FinancasApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para configurarmos a conexão do banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //adicionando a connectionstring do banco de dados
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDFinancasApp;Integrated Security=True;");
        }

        /// <summary>
        /// Método para adicionarmos as classes de mapeamento
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
