using Microsoft.EntityFrameworkCore;

namespace CleaningSolution.Model
{
    public class CleaningPlanDbContext : DbContext //<CleaningPlanDbContext>
    {
        public CleaningPlanDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<CleaningPlan> CleaningPlans { get; set; }


    }
}
