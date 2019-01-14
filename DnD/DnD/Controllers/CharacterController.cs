using DnD.Characters.Data;
using DnD.Characters.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DnD.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public Character Post(Character character)
        {
            return character;
        }

        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return _characterRepository.Characters;
        }
    }
}
