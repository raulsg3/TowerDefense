using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace TowerDefense.EditModeTests
{
    public class CreepCounterTests
    {
        private void IncreaseCreeps(ICreepCounter creepCounter, int numIncreases)
        {
            ICreep creep = Substitute.For<ICreep>();

            for (int inc = 0; inc < numIncreases; ++inc)
                creepCounter.IncreaseCreepsRemaining(creep);
        }

        private void DecreaseCreeps(ICreepCounter creepCounter, int numDecreases)
        {
            ICreep creep = Substitute.For<ICreep>();

            for (int inc = 0; inc < numDecreases; ++inc)
                creepCounter.DecreaseCreepsRemaining(creep);
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(5, 3)]
        public void GetNumCreepsRemaining_ReturnNumIncreasesMinusNumDecreases(int numIncreases, int numDecreases)
        {
            //Arrange
            ICreepCounter creepCounter = new CreepCounter();

            //Act
            IncreaseCreeps(creepCounter, numIncreases);
            DecreaseCreeps(creepCounter, numDecreases);

            //Assert
            Assert.AreEqual(numIncreases - numDecreases, creepCounter.GetNumCreepsRemaining());
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(5, 3)]
        public void GetNumCreepsEliminated_ReturnNumDecreases(int numIncreases, int numDecreases)
        {
            //Arrange
            ICreepCounter creepCounter = new CreepCounter();

            //Act
            IncreaseCreeps(creepCounter, numIncreases);
            DecreaseCreeps(creepCounter, numDecreases);

            //Assert
            Assert.AreEqual(numDecreases, creepCounter.GetNumCreepsEliminated());
        }
    }
}