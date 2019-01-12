using System;
using System.Collections.Generic;
using System.Text;

namespace DnD.Characters.Domain
{
    public class Dwarf : Race
    {
        private readonly int ConstitutionBonus = 2;

        public override void ApplyEffects(Character character)
        {
            character.Constitution += ConstitutionBonus;
        }

        public override void RemoveEffects(Character character)
        {
            character.Constitution -= ConstitutionBonus;
        }
    }
}
