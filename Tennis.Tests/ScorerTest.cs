using NUnit.Framework;
using Tennis.Logic;

namespace Tennis.Tests
{
    [TestFixture]
    public class ScorerTest
    {
        [Test]
        public void GetScore_WithZeroPoints_ReturnsLoveLove()
        {
            Scorer scorer = new Scorer();

            Assert.AreEqual("love - love", scorer.GetScore(0, 0));
        }

        [Test]
        [TestCase(1, "fifteen")]
        [TestCase(2, "thirty")]
        [TestCase(3, "forty")]
        public void GetPlayerScore_WithValidPoints_ReturnsCorrectScore(int playerPoints, string expected)
        {
            Scorer scorer = new Scorer();

            Assert.AreEqual(expected, scorer.GetPlayerScore(playerPoints));
        }
    }
}
