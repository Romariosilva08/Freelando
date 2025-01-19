using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freelando.Dados;
public class FreelandoClientesContext: DbContext
{
    public FreelandoClientesContext(DbContextOptions<FreelandoClientesContext> options) : base(options)
    {
    }

    private string _connectionString = "Data Source=DESKTOP-T6S5O68\\SQLEXPRESS;Initial Catalog=Freelando0;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

   public DbSet<ClienteNew> ClienteNew { get; set; }
    

}

public class ClienteNew
{
    public ClienteNew()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public DateTime DataInclusao { get; set; }
}
