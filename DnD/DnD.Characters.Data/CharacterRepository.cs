using DnD.Characters.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DnD.Characters.Data
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(DnDContext context) : base(context)
        { }

        public IEnumerable<Character> Characters => _context.Characters.AsEnumerable();
    }
}
