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

        public ManageCharacterViewModel CharacterModel { get; set; } = new ManageCharacterViewModel();

        public void OnGet(int? id)
        {
        }
    }

    
}