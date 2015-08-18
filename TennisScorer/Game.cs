using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Logic
{
    public class Game
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Boolean GameIsComplete;
        private Scorer _scorer;
        private IReportingService reportingService;

        public Game()
        {
            Player1 = new Player();
            Player2= new Player();
            GameIsComplete = false;
            _scorer = new Scorer();
        }

        public Game(IReportingService reportingService) : this()
        {
            this.reportingService = reportingService;
        }

        public string GetScore()
        {                        
            var score = _scorer.GetScore(Player1.GetPoints(), Player2.GetPoints());

            GameIsComplete = _scorer.GameIsComplete;

            if (GameIsComplete)
            {
                reportingService.SendScore();                
            }

            return score;
        }        
    }
}
