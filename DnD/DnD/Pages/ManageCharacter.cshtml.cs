using DnD.Characters.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DnD.Pages
{
    public class ManageCharacterModel : PageModel
    {
        private ICharacterRepository _characterRepository;

        public ManageCharacterModel(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        //public Task OnPost(Character character)
        //{
        //    await _chara;
        //}

        public async Task OnGet()
        {
             await _characterRepository.ListAllAsync();
        }

        //public class IEnumerable<ManageCharacterViewModel> CharacterModels { get; set; }
    }

    
}