using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace TowerDefense.EditModeTests
{
    public class CreepCounterTests
    {
        readonly ICreep _creep = Substitute.For<ICreep>();
        readonly IEventService _eventManagerService = Substitute.For<IEventService>();

        ICreepCounter _creepCounter = null;

        [SetUp]
        public void SetUp()
        {
            ServiceLocatorSingleton.Instance.RegisterService<IEventService>(_eventManagerService);
            _creepCounter = new CreepCounter();
        }

        [TearDown]
        public void TearDown()
        {
            ServiceLocatorSingleton.Instance.ClearServices();
            _eventManagerService.ClearReceivedCalls();
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
            _creepCounter.IncreaseCreepsRemaining(_creep);

            Assert.AreEqual(numCreepsRemainingBeforeIncreasing + 1, _creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void DecreaseCreepsRemaining_DecrementsRemainingCreepsByOne()
        {
            int numCreepsRemainingBeforeDecreasing = _creepCounter.GetNumCreepsRemaining();
            _creepCounter.DecreaseCreepsRemaining(_creep);

            Assert.AreEqual(numCreepsRemainingBeforeDecreasing - 1, _creepCounter.GetNumCreepsRemaining());
        }

        [Test]
        public void DecreaseCreepsRemaining_IncrementsEliminatedCreepsByOne()
        {
            int numCreepsEliminatedBeforeDecreasing = _creepCounter.GetNumCreepsEliminated();
            _creepCounter.DecreaseCreepsRemaining(_creep);

            Assert.AreEqual(numCreepsEliminatedBeforeDecreasing + 1, _creepCounter.GetNumCreepsEliminated());
        }

        [TestCase(1, 0)]
        [TestCase(3, 2)]
        public void DecreaseCreepsRemaining_CreepsRemainingIsTrue_DoesNotTriggerEventAllCreepsEliminated(int numIncreaseCalls, int numDecreaseCalls)
        {
            IncreaseCreeps(_creepCounter, numIncreaseCalls);
            DecreaseCreeps(_creepCounter, numDecreaseCalls);

            _eventManagerService.Received(0).AllCreepsEliminated();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void DecreaseCreepsRemaining_CreepsRemainingIsFalse_TriggersEventAllCreepsEliminated(int numIncreaseCalls, int numDecreaseCalls)
        {
            IncreaseCreeps(_creepCounter, numIncreaseCalls);
            DecreaseCreeps(_creepCounter, numDecreaseCalls);

            _eventManagerService.Received(1).AllCreepsEliminated();
        }

        private void IncreaseCreeps(ICreepCounter creepCounter, int numIncreaseCalls)
        {
            for (int inc = 0; inc < numIncreaseCalls; ++inc)
                creepCounter.IncreaseCreepsRemaining(_creep);
        }

        private void DecreaseCreeps(ICreepCounter creepCounter, int numDecreaseCalls)
        {
            for (int inc = 0; inc < numDecreaseCalls; ++inc)
                creepCounter.DecreaseCreepsRemaining(_creep);
        }
    }
}