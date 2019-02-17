using DnD.Characters.Core.Entities;
using DnD.Characters.Core.Interfaces;

namespace DnD.Characters.Infrastructure.Data
{
    public interface ICharacterRepository : IAsyncRepository<Character>
    { }
}
