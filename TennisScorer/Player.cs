namespace Tennis.Logic
{
    public class Player
    {
        public int PointTotal { get; private set; }

        public void ScorePoint()
        {
            PointTotal++;
        }

        public int GetPoints()
        {
            return PointTotal;
        }
    }
}