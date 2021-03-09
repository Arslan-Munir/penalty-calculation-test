
using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.API.Entities;

namespace PenaltyCalculation.API.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<WeekHoliday> WeekHolidays { get; set; }
    }
}