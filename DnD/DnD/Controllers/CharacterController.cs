using System;
using System.Collections.Generic;
using DnD.Characters.Data;
using DnD.Characters.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DnD.Controllers
{
    public class CharacterController
    {
        private ICharacterRepository repo;

        public CharacterController(ICharacterRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public Character Post(Character character)
        {
            return character;
        }

        public IEnumerable<Character> Get()
        {
            return repo.Characters;
        }
    }
}
