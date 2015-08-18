using NUnit.Framework;
using Tennis.Logic;

namespace Tennis.Tests
{    
    [TestFixture]
    public class PlayerTest
    {                
        [Test]
        public void GetPoints_WithNewPlayer_Returns0()
        {
            Player player = new Player();

            Assert.AreEqual(0, player.GetPoints());
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void GetPoints_WithValidNumberOfPoints_ReturnsPointTotal(int numberOfPoints, int expected)
        {
            Player player = new Player();

            for (int i = 0; i < numberOfPoints; i++)
            {
                player.ScorePoint();    
            }
            
            Assert.AreEqual(expected, player.GetPoints());
        }
    }
}
