using System;
using System.Collections.Generic;

namespace DnD.Characters.Core.Entities
{
    public class Bard : Class
    {
        public override void ApplyEffects(Character character)
        {
            foreach (var ability in Abilities)
            {
                character.Abilities.Add(ability);
            }
        }

        public override void RemoveEffects(Character character)
        {
            foreach (var ability in Abilities)
            {
                character.Abilities.Remove(ability);
            }
        }

        public List<Ability> Abilities =>
            new List<Ability>()
            {
                new BardicInspiration()
            };
    }
}
