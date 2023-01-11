using Microsoft.EntityFrameworkCore;
using WebApplicationSolution.APIWeb.Models;

namespace APIWeb.Data
{
    public class ApiWebContext : DbContext
    {
        public ApiWebContext(DbContextOptions<ApiWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<EnderecoCliente> Endereco { get; set; }
    }
}
