using DnD.Characters.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DnD.Characters.Data
{
    public class DnDContext : DbContext
    {
        private readonly IConfiguration _config;

        public DnDContext(IConfiguration config, DbContextOptions<DnDContext> options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Character> Characters { get; set; }
    }
}
