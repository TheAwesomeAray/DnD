using System;

namespace DnD.Characters.Domain
{
    public abstract class Race
    {
        public abstract void ApplyEffects(Character character);
        public abstract void RemoveEffects(Character character);
    }
}
