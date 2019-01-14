namespace DnD.Characters.Domain
{
    public abstract class Class
    {
        public abstract void ApplyEffects(Character character);
        public abstract void RemoveEffects(Character character);
    }
}
