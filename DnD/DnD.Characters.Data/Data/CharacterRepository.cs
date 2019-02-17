using DnD.Characters.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnD.Characters.Infrastructure.Data
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(DnDContext context) : base(context)
        { }
    }
}
