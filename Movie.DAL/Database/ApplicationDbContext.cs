namespace Movie.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }
        
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Gener> Geners { get; set; }
    }
}
