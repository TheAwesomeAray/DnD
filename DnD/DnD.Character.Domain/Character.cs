using System;
using DnD.Characters.Domain.Enums;

namespace DnD.Characters.Domain
{
    public class Character
    {
        public CharacterCreationStatus CreationStatus { get; private set; }
        public Race Race { get; set; }

        public int Strength { get; internal set; }
        public int Dexterity { get; internal set; }
        public int Constitution { get; internal set; }
        public int Intelligence { get; internal set; }
        public int Wisdom { get; internal set; }
        public int Charisma { get; internal set; }

        public Character()
        {
            CreationStatus = CharacterCreationStatus.Start;
        }

        public void AssignRace(Race race)
        {
            Race = race;
            race.ApplyEffects(this);
            CreationStatus = CharacterCreationStatus.Class;
        }

        public void RemoveRace(Race race)
        {
            race.RemoveEffects(this);
        }
    }
}
