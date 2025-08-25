using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Models;

namespace VacinaBtgApi.Data
{
    public class VacinaDbContext : DbContext
    {
        public VacinaDbContext(DbContextOptions<VacinaDbContext> options) : base(options) { }

        public DbSet<Vacina> Vacinas { get; set; }
    }
}
