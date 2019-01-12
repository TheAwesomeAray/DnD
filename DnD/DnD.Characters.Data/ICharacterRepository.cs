using DnD.Characters.Domain;
using System.Collections.Generic;

namespace DnD.Characters.Data
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> Characters { get; }
    }
}
