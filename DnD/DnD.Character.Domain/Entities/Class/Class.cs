namespace DnD.Characters.Core.Entities
{
    public abstract class Class
    {
        public abstract void ApplyEffects(Character character);
        public abstract void RemoveEffects(Character character);
    }
}
