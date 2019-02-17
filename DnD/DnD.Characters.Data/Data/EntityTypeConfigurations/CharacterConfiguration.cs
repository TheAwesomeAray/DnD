using DnD.Characters.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnD.Characters.Infrastrtucture.Data.EntityTypeConfigurations
{
    internal class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Ignore(c => c.Race);
            builder.Ignore(c => c.Abilities);
            builder.Ignore(c => c.Class);
        }
    }
}
