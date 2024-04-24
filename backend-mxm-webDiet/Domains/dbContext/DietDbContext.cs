using Microsoft.EntityFrameworkCore;
using mxm_webDiet.Domains.Models;

namespace mxm_webDiet.Domains.dbContext;

public class DietDbContext : DbContext
{

    public DbSet<Dietas> Dietas { get; set; }

    public DietDbContext(DbContextOptions<DietDbContext> options)
     : base(options)
    {
    }


}