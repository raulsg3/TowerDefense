using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace TowerDefense.EditModeTests
{
    public class CreepCounterTests
    {
        readonly ICreep creep = Substitute.For<ICreep>();

        ICreepCounter _creepCounter = null;

        [SetUp]
        public void SetUp()
        {
            _creepCounter = new CreepCounter();
        }

        [Test]
        public void GetNumCreepsRemaining_InitialValue_ReturnsZero()
        {
            Assert.AreEqual(0, _creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void GetNumCreepsEliminated_InitialValue_ReturnsZero()
        {
            Assert.AreEqual(0, _creepCounter.GetNumCreepsEliminated());
        }

        [TestCase(3, 0)]
        [TestCase(1, 1)]
        public void GetNumTotalCreeps_MultipleCallsToIncreaseAndDecrease_ReturnsNumRemainingPlusNumEliminated(int numIncreaseCalls, int numDecreaseCalls)
        {
            IncreaseCreeps(_creepCounter, numIncreaseCalls);
            DecreaseCreeps(_creepCounter, numDecreaseCalls);

            Assert.AreEqual(_creepCounter.GetNumCreepsRemaining() + _creepCounter.GetNumCreepsEliminated(), _creepCounter.GetNumTotalCreeps());
        }

        [TestCase(1, 0)]
        [TestCase(3, 2)]
        public void AreCreepsRemaining_MoreCallsToIncreaseThanDecrease_ReturnsTrue(int numIncreaseCalls, int numDecreaseCalls)
        {
            IncreaseCreeps(_creepCounter, numIncreaseCalls);
            DecreaseCreeps(_creepCounter, numDecreaseCalls);

            Assert.Greater(_creepCounter.GetNumCreepsRemaining(), 0);
            Assert.True(_creepCounter.AreCreepsRemaining());
        }

        [TestCase(0, 0)]
        [TestCase(2, 2)]
        public void AreCreepsRemaining_SameCallsToIncreaseAndDecrease_ReturnsFalse(int numIncreaseCalls, int numDecreaseCalls)
        {
            IncreaseCreeps(_creepCounter, numIncreaseCalls);
            DecreaseCreeps(_creepCounter, numDecreaseCalls);

            Assert.AreEqual(_creepCounter.GetNumCreepsRemaining(), 0);
            Assert.False(_creepCounter.AreCreepsRemaining());
        }

        [Test]
        public void IncreaseCreepsRemaining_IncrementsRemainingCreepsByOne()
        {
            int numCreepsRemainingBeforeIncreasing = _creepCounter.GetNumCreepsRemaining();
            _creepCounter.IncreaseCreepsRemaining(creep);

            Assert.AreEqual(numCreepsRemainingBeforeIncreasing + 1, _creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void DecreaseCreepsRemaining_DecrementsRemainingCreepsByOne()
        {
            int numCreepsRemainingBeforeDecreasing = _creepCounter.GetNumCreepsRemaining();
            _creepCounter.DecreaseCreepsRemaining(creep);

            Assert.AreEqual(numCreepsRemainingBeforeDecreasing - 1, _creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void DecreaseCreepsRemaining_IncrementsEliminatedCreepsByOne()
        {
            int numCreepsEliminatedBeforeDecreasing = _creepCounter.GetNumCreepsEliminated();
            _creepCounter.DecreaseCreepsRemaining(creep);

            Assert.AreEqual(numCreepsEliminatedBeforeDecreasing + 1, _creepCounter.GetNumCreepsEliminated());
        }

        private void IncreaseCreeps(ICreepCounter _creepCounter, int numIncreaseCalls)
        {
            for (int inc = 0; inc < numIncreaseCalls; ++inc)
                _creepCounter.IncreaseCreepsRemaining(creep);
        }

        private void DecreaseCreeps(ICreepCounter _creepCounter, int numDecreaseCalls)
        {
            for (int inc = 0; inc < numDecreaseCalls; ++inc)
                _creepCounter.DecreaseCreepsRemaining(creep);
        }
    }
}