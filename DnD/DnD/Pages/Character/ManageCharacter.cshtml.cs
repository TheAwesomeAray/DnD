using DnD.Characters.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD.Pages.Character
{
    public class ManageCharacterModel : PageModel
    {
        private ICharacterRepository _characterRepository;

        public ManageCharacterModel(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public CharacterViewModel CharacterModel { get; set; } = new CharacterViewModel();

        public void OnGet(int? characterId)
        {
            if (characterId != null)
            {
                CharacterModel = new List<CharacterViewModel>()
                {
                    new CharacterViewModel() { Id = 1, Name = "Kagor" },
                    new CharacterViewModel() { Id = 2, Name = "Bellocke" },
                    new CharacterViewModel() { Id = 3, Name = "Mayleia" }
                }.Single(x => x.Id == characterId);
            }
        }
    }

    
}