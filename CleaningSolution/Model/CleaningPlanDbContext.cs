
using Microsoft.EntityFrameworkCore;

namespace CleaningSolution.Model
{
    public class CleaningPlanDbContext : DbContext //<CleaningPlanDbContext>
    {
        //public CleaningPlanDbContext(DbContextOptions options) : base(options)
        //{
            
        //}

        public CleaningPlanDbContext(DbContextOptions<CleaningPlanDbContext> options) : base(options)
        {
        }

        public DbSet<CleaningPlan> CleaningPlans { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<CleaningPlan>().HasData(
        //        new CleaningPlan
        //        {
        //            //id = Guid.Parse("8c442581-c67a-41e5-8d2d-b1176de31087"),
        //            id = Guid.NewGuid(),
        //            createdAt = DateTime.Now,
        //            customerId = 123223,
        //            title = "Hotel Room Cleaning, double bed",
        //            description = "This plan is meant to be used for double bed rooms."
        //        });

        //    modelBuilder.Entity<CleaningPlan>().HasData(
        //        new CleaningPlan
        //        {
        //            id = Guid.NewGuid(),
        //            createdAt = DateTime.Now,
        //            customerId = 123223,
        //            title = "Mall Cleaning, inner city",
        //            description = "Suitable only for malls smaller than 23000 m²."
        //        });

        //    modelBuilder.Entity<CleaningPlan>().HasData(
        //        new CleaningPlan
        //        {
        //            id = Guid.NewGuid(),
        //            createdAt = DateTime.Now,
        //            customerId = 144444,
        //            title = "Ciscenje ureda",
        //            description = "Samo za poslovne svrhe."
        //        });
        //}
    }
}
