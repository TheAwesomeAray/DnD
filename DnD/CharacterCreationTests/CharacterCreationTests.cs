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
                
                dummy.Verify(d => d.ApplyEffects(character), Times.Once);
            }

            [Fact]
            public void RemovingRaceShouldRemoveRacialEffects()
            {
                var character = new Character();
                var dummy = new Mock<Race>();
                character.AssignRace(dummy.Object);
                character.RemoveRace();

                dummy.Verify(d => d.RemoveEffects(character), Times.Once);
            }

            [Fact]
            public void RaceShouldNotBeRemovedIfNoRaceIsAssigned()
            {
                var character = new Character();
                var dummy = new Mock<Race>();
                character.AssignRace(dummy.Object);
                character.RemoveRace();
                character.RemoveRace();

                dummy.Verify(d => d.RemoveEffects(character), Times.Once);
            }

            [Fact]
            public void ApplyRaceWhenRaceIsAlreadyAssignedRemovesCurrentRace()
            {
                var character = new Character();
                var dwarfDummy = new Mock<Dwarf>();
                var elfDummy = new Mock<Elf>();
                character.AssignRace(dwarfDummy.Object);
                character.AssignRace(elfDummy.Object);

                dwarfDummy.Verify(d => d.ApplyEffects(character), Times.Once);
                dwarfDummy.Verify(d => d.RemoveEffects(character), Times.Once);
                elfDummy.Verify(e => e.ApplyEffects(character), Times.Once);
            }

            public class RaceData : TheoryData<Race>
            {
                public RaceData()
                {
                    Add(new Dwarf());
                    Add(new Elf());
                    Add(new Human());
                    Add(null);
                }
            }
        }

        
        public class ClassTests
        {
            [Theory]
            [ClassData(typeof(ClassData))]
            public void CharacterShouldBeAssignedAClass(Class characterClass)
            {
                var character = new Character();

                character.AssignClass(characterClass);

                Assert.Equal(characterClass, character.Class);
            }

            [Fact]
            public void CharacterClassShouldApplyClassBenefitsWhenAssigned()
            {
                var character = new Character();
                var bardDummy = new Mock<Bard>();
                character.AssignClass(bardDummy.Object);

                bardDummy.Verify(d => d.ApplyEffects(character), Times.Once);
            }

            [Fact]
            public void CharacterShouldRemoveCurrentClassWhenAssignNewClass()
            {
                var character = new Character();
                var bardDummy = new Mock<Bard>();
                var barbarianDummy = new Mock<Barbarian>();
                character.AssignClass(bardDummy.Object);
                character.AssignClass(barbarianDummy.Object);

                bardDummy.Verify(d => d.ApplyEffects(character), Times.Once);
                bardDummy.Verify(d => d.RemoveEffects(character), Times.Once);
                barbarianDummy.Verify(e => e.ApplyEffects(character), Times.Once);
            }
        }

        public class ClassData : TheoryData<Class>
        {
            public ClassData()
            {
                Add(new Wizard());
                Add(new Barbarian());
                Add(new Bard());
                Add(null);
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
