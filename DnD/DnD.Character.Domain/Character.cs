using DnD.Characters.Domain.Enums;
using System;
using System.Collections.Generic;

namespace DnD.Characters.Domain
{
    public class Character
    {
        public CharacterCreationStatus CreationStatus { get; private set; }
        public Race Race { get; private set; }
        public Class Class { get; private set; }
        public List<Ability> Abilities { get; internal set; } = new List<Ability>();

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
            if (race == null)
                return;

            if (Race != null)
                RemoveRace();

            Race = race;
            race.ApplyEffects(this);
            CreationStatus = CharacterCreationStatus.Class;
        }

        public void RemoveRace()
        {
            if (Race != null)
            {
                Race.RemoveEffects(this);
                Race = null;
            }
        }

        public void AssignClass(Class characterClass)
        {
            if (characterClass == null)
                return;

            if (Class != null)
                Class.RemoveEffects(this);

            Class = characterClass;
            Class.ApplyEffects(this);
        }

        public void RemoveClass()
        {
            if (Class == null)
                return;

            Class.RemoveEffects(this);
            Class = null;
        }
    }
}
