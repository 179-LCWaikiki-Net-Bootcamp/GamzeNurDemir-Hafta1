using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GamzeNurDemir_Hafta1.Entities
{
    public class Hafta1DenemeDbContext :DbContext
    {
        private readonly IConfiguration _configuration;
        public Hafta1DenemeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }
        //public Hafta1DenemeDbContext(DbContextOptions<Hafta1DenemeDbContext>options) : base(options)   
        //{

        //}

        public DbSet<User> Users { get; set; }
    }
}
