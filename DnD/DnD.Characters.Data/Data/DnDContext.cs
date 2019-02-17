using DnD.Characters.Core.Entities;
using DnD.Characters.Infrastrtucture.Data.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DnD.Characters.Infrastructure.Data
{
    public class DnDContext : DbContext
    {
        private readonly IConfiguration _config;

        public DnDContext(IConfiguration config, DbContextOptions<DnDContext> options)
            : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        }

        public DbSet<Character> Characters { get; set; }
    }
}
