namespace DnD.Characters.Core.Entities
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
