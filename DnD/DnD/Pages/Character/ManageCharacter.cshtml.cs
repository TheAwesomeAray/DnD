using DnD.Characters.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void OnGet(int? id)
        {
        }
    }

    
}