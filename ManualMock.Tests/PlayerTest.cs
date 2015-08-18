using ManualMock.Logic;
using NUnit.Framework;

namespace ManualMock.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void LowRollShouldMiss()
        {
            IRollable d20 = new MockDie(7);
            Player badFighter = new Player(d20);
            Orc anOrc = new Orc();

            Assert.IsFalse(badFighter.Attack(anOrc));
        }

        [Test]
        public void HighRollShouldHit()
        {
            IRollable d20 = new MockDie(18);
            Player goodFighter = new Player(d20);
            Orc anOrc = new Orc();

            Assert.IsTrue(goodFighter.Attack(anOrc));
        }

        [Test]
        public void OrcShouldNotDie()
        {
            MockGame mockGame = new MockGame();
            Orc strongOrc = new Orc(mockGame, 30);

            MockDie d20 = new MockDie();
            d20.AddRoll(18);
            d20.AddRoll(10);

            Player fighter = new Player(d20);
            fighter.Attack(strongOrc);

            Assert.IsFalse(strongOrc.IsDead());
            mockGame.Verify();
        }

        [Test]
        public void OrcShouldDie()
        {
            MockGame mockGame = new MockGame();
            Orc weakOrc = new Orc(mockGame, 10);
            mockGame.ExpectHasDied(weakOrc);

            MockDie d20 = new MockDie();
            d20.AddRoll(18);
            d20.AddRoll(10);

            Player fighter = new Player(d20);
            fighter.Attack(weakOrc);

            Assert.IsTrue(weakOrc.IsDead());
            mockGame.Verify();
        }


    }

    public class MockGame : IGame
    {
        private Orc orcExpectedToDie = null;
        private Orc deadOrc = null;

        public void HasDied(Orc orc)
        {
            if (orc != orcExpectedToDie)
            {
                Assert.Fail("Unexpected orc died.");
            }

            deadOrc = orc;
        }

        public void ExpectHasDied(Orc orc)
        {
            orcExpectedToDie = orc;
        }

        public void Verify()
        {
            Assert.AreEqual(orcExpectedToDie, deadOrc);
        }
    }
}
