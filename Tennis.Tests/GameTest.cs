using NUnit.Framework;
using Tennis.Logic;

namespace Tennis.Tests
{
    [TestFixture]
    public class GameTest
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }


        [Test]
        public void GetScore_WithNewGame_ReturnsLoveLove()
        {            
            Assert.AreEqual("love - love", game.GetScore());
        }

        [Test]
        [TestCase(1, 0, "fifteen - love")]
        [TestCase(1, 1, "fifteen - fifteen")]
        [TestCase(1, 2, "fifteen - thirty")]
        [TestCase(2, 2, "thirty - thirty")]
        [TestCase(3, 2, "advantage player 1")]
        [TestCase(3, 3, "deuce")]
        [TestCase(4, 3, "advantage player 1")]
        [TestCase(4, 5, "advantage player 2")]
        [TestCase(4, 2, "winner player 1")]
        [TestCase(4, 6, "winner player 2")]
        [TestCase(6, 6, "deuce")]
        public void GetScore_WithValidPoints_ReturnsCorrectScore(int numberOfPlayer1Points, int numberOfPlayer2Points, string expected)
        {
            IReportingService reportingService = new DummyReportingService();
            Game gameWithReportingService = new Game(reportingService);

            for (int i = 0; i < numberOfPlayer1Points; i++)
            {
                gameWithReportingService.Player1.ScorePoint();    
            }

            for (int i = 0; i < numberOfPlayer2Points; i++)
            {
                gameWithReportingService.Player2.ScorePoint();
            }
            
            Assert.AreEqual(expected, gameWithReportingService.GetScore());
        }

        [Test]
        public void GameIsComplete_WhenThereIsAWinner_ReturnsTrue()
        {            
            IReportingService reportingService = new DummyReportingService();
            Game gameWithReportingService = new Game(reportingService);

            ScorePoints(gameWithReportingService, 4, 2);
            var score = gameWithReportingService.GetScore();

            Assert.AreEqual(true, gameWithReportingService.GameIsComplete);
        }





        [Test]
        public void SendScore_WhenGameIsComplete_ShouldBeCalled()
        {
            DummyReportingService reportingService = new DummyReportingService();
            Game game = new Game(reportingService);

            ScorePoints(game, 4, 2);                                   
            var score = game.GetScore();

            Assert.IsTrue(reportingService.SendScoreWasCalled());
        }







        private void ScorePoints(Game game, int numberOfPlayer1Points, int numberOfPlayer2Points)
        {
            for (int i = 0; i < numberOfPlayer1Points; i++)
            {
                game.Player1.ScorePoint();
            }

            for (int i = 0; i < numberOfPlayer2Points; i++)
            {
                game.Player2.ScorePoint();
            }
        }
    }
}
