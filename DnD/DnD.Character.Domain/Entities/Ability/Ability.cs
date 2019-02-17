namespace DnD.Characters.Core.Entities
{
    public abstract class Ability
    {
        public abstract string Name { get; }

        public override bool Equals(object obj)
        {
            var ability = obj as Ability;
            return Name == ability.Name;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
