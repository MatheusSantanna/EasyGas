using EasyGas.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyGas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Colaboradores> Colaboradores { get; set; }

    public DbSet<Faturamento> Faturamento { get; set; }

    public DbSet<OrdemServico> OrdemServico { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}