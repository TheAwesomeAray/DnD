namespace DnD.Characters.Core.Entities
{
    public abstract class Race
    {
        public abstract void ApplyEffects(Character character);
        public abstract void RemoveEffects(Character character);
    }
}
