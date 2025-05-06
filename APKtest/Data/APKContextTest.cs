using APKtest.Models;
using Microsoft.EntityFrameworkCore;

namespace APKtest.Data
{
    public class APKContextTest : DbContext
    {
        public APKContextTest(DbContextOptions<APKContextTest> options) : base(options) { }
        public DbSet<APKtest.Models.MeritveA> Meritve { get; set; } = default!;
        public DbSet<APKtest.Models.Merilna_Naprava> Merilna_Naprava { get; set; } = default!;
        public DbSet<APKtest.Models.Metrolog> Metrolog { get; set; } = default!;

    }
}