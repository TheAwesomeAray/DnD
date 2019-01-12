using DnD.Characters.Data;
using DnD.Characters.Domain;
using DnD.Characters.Domain.Enums;
using DnD.Controllers;
using Moq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CharacterCreationTests
{
    public class CharacterCreationTests
    {
        [Fact]
        public void PostReturnsCreatedCharacter()
        {
            var controller = new CharacterController(new Mock<ICharacterRepository>().Object);
            var expected = new Character();

            var actual = controller.Post(expected);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReturnsCharacterInRepository()
        {
            var character1 = new Character();
            var repo = new Mock<ICharacterRepository>();
            repo.Setup(r => r.Characters).Returns(new List<Character>() { character1 });
            var controller = new CharacterController(repo.Object);
            
            var characters = controller.Get();

            Assert.Contains(character1, characters);
        }

        [Fact]
        public void NewlyCreatedCharactersShouldBeGivenStartStatus()
        {
            var character = new Character();

            Assert.Equal(CharacterCreationStatus.Start, character.CreationStatus);
        }

        public class RaceSelectionTests
        {
            [Theory]
            [ClassData(typeof(RaceData))]
            public void CharacterShouldBeAssignedARace(Race race)
            {
                var character = new Character();

                character.AssignRace(race);

                Assert.Equal(race, character.Race);
            }

            [Fact]
            public void CharacterCreationProgressShouldBeUpdatedWhenRaceIsAssigned()
            {
                var character = new Character();

                character.AssignRace(new Dwarf());

                Assert.Equal(CharacterCreationStatus.Class, character.CreationStatus);
            }

            [Fact]
            public void AssigningRaceShouldApplyRacialEffects()
            {
                var character = new Character();
                var dummy = new Mock<Race>();
                character.AssignRace(dummy.Object);
                
                dummy.Verify(r => r.ApplyEffects(character), Times.Once);
            }

            [Fact]
            public void RemovingRaceShouldRemoveRacialEffects()
            {
                var character = new Character();
                var dummy = new Mock<Race>();
                character.RemoveRace(dummy.Object);

                dummy.Verify(r => r.RemoveEffects(character), Times.Once);
            }

            public class RaceData : TheoryData<Race>
            {
                public RaceData()
                {
                    Add(new Dwarf());
                    Add(new Elf());
                    Add(new Human());
                }
            }
        }




        //Track Progress through creation
        //XP
        //HP
        //Races
        //Classes
        //Ability Scores

    }
}
