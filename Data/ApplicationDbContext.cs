using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcPietro.Models;

namespace MvcPietro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MvcPietro.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<MvcPietro.Models.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<MvcPietro.Models.Produto> Produto { get; set; } = default!;
        public DbSet<MvcPietro.Models.Venda> Venda { get; set; } = default!;
        public DbSet<MvcPietro.Models.VendaProduto> VendaProduto { get; set; } = default!;
    }
}
