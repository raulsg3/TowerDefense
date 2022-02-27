using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace TowerDefense.EditModeTests
{
    public class CreepCounterTests
    {
        readonly ICreep creep = Substitute.For<ICreep>();

        private void IncreaseCreeps(ICreepCounter creepCounter, int numIncreaseCalls)
        {
            for (int inc = 0; inc < numIncreaseCalls; ++inc)
                creepCounter.IncreaseCreepsRemaining(creep);
        }

        private void DecreaseCreeps(ICreepCounter creepCounter, int numDecreaseCalls)
        {
            for (int inc = 0; inc < numDecreaseCalls; ++inc)
                creepCounter.DecreaseCreepsRemaining(creep);
        }

        [Test]
        public void GetNumCreepsRemaining_InitialValue_ReturnsZero()
        {
            ICreepCounter creepCounter = new CreepCounter();

            Assert.AreEqual(0, creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void GetNumCreepsEliminated_InitialValue_ReturnsZero()
        {
            ICreepCounter creepCounter = new CreepCounter();

            Assert.AreEqual(0, creepCounter.GetNumCreepsEliminated());
        }

        [TestCase(3, 0)]
        [TestCase(1, 1)]
        public void GetNumTotalCreeps_MultipleCallsToIncreaseAndDecrease_ReturnsNumRemainingPlusNumEliminated(int numIncreaseCalls, int numDecreaseCalls)
        {
            ICreepCounter creepCounter = new CreepCounter();

            IncreaseCreeps(creepCounter, numIncreaseCalls);
            DecreaseCreeps(creepCounter, numDecreaseCalls);

            Assert.AreEqual(creepCounter.GetNumCreepsRemaining() + creepCounter.GetNumCreepsEliminated(), creepCounter.GetNumTotalCreeps());
        }

        [TestCase(1, 0)]
        [TestCase(3, 2)]
        public void AreCreepsRemaining_MoreCallsToIncreaseThanDecrease_ReturnsTrue(int numIncreaseCalls, int numDecreaseCalls)
        {
            ICreepCounter creepCounter = new CreepCounter();

            IncreaseCreeps(creepCounter, numIncreaseCalls);
            DecreaseCreeps(creepCounter, numDecreaseCalls);

            Assert.Greater(creepCounter.GetNumCreepsRemaining(), 0);
            Assert.True(creepCounter.AreCreepsRemaining());
        }

        [TestCase(0, 0)]
        [TestCase(2, 2)]
        public void AreCreepsRemaining_SameCallsToIncreaseAndDecrease_ReturnsFalse(int numIncreaseCalls, int numDecreaseCalls)
        {
            ICreepCounter creepCounter = new CreepCounter();

            IncreaseCreeps(creepCounter, numIncreaseCalls);
            DecreaseCreeps(creepCounter, numDecreaseCalls);

            Assert.AreEqual(creepCounter.GetNumCreepsRemaining(), 0);
            Assert.False(creepCounter.AreCreepsRemaining());
        }

        [Test]
        public void IncreaseCreepsRemaining_IncrementsRemainingCreepsByOne()
        {
            ICreepCounter creepCounter = new CreepCounter();

            int numCreepsRemainingBeforeIncreasing = creepCounter.GetNumCreepsRemaining();
            creepCounter.IncreaseCreepsRemaining(creep);

            Assert.AreEqual(numCreepsRemainingBeforeIncreasing + 1, creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void DecreaseCreepsRemaining_DecrementsRemainingCreepsByOne()
        {
            ICreepCounter creepCounter = new CreepCounter();

            int numCreepsRemainingBeforeDecreasing = creepCounter.GetNumCreepsRemaining();
            creepCounter.DecreaseCreepsRemaining(creep);

            Assert.AreEqual(numCreepsRemainingBeforeDecreasing - 1, creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void DecreaseCreepsRemaining_IncrementsEliminatedCreepsByOne()
        {
            ICreepCounter creepCounter = new CreepCounter();

            int numCreepsEliminatedBeforeDecreasing = creepCounter.GetNumCreepsEliminated();
            creepCounter.DecreaseCreepsRemaining(creep);

            Assert.AreEqual(numCreepsEliminatedBeforeDecreasing + 1, creepCounter.GetNumCreepsEliminated());
        }
    }
}