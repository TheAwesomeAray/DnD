using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DnD.Pages.Character
{
    public class CharacterListModel : PageModel
    {
        public CharacterListModel()
        {
            Characters = new List<CharacterViewModel>()
            {
                new CharacterViewModel() { Id = 1, Name = "Kagor" },
                new CharacterViewModel() { Id = 2, Name = "Bellocke" },
                new CharacterViewModel() { Id = 3, Name = "Mayleia" }
            };
        }

        public IEnumerable<CharacterViewModel> Characters { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Characters = Characters.Where(x => string.IsNullOrEmpty(SearchTerm) || x.Name.StartsWith(SearchTerm));
        }
    }
}