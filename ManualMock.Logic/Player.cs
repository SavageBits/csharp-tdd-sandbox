using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ManualMock.Logic
{
    public class Player
    {
        private IRollable myD20 = null;

        public Player(IRollable d20)
        {
            myD20 = d20;
        }

        public Boolean Attack(Orc anOrc)
        {
            if (myD20.Roll() >= 13)
            {
                return hit(anOrc);
            }
            else
            {
                return miss();
            }
        }

        private bool hit(Orc anOrc)
        {
            anOrc.Injure(myD20.Roll());
            return true;
        }

        private bool miss()
        {
            return false;
        }
    }

    public class Die: IRollable
    {
        private int sides = 0;
        private Random generator;

        public Die(int numberOfSides)
        {
            sides = numberOfSides;
            generator = new Random();
        }

        public int Roll()
        {
            return generator.Next(sides) + 1;
        }
    }

    public class MockDie : IRollable
    {
        private int nextIndexToReturn = 0;
        private List<int> returnValues = new List<int>();

        public MockDie()
        {
            
        }

        public MockDie(int aReturnValue)
        {            
            AddRoll(aReturnValue);
        }

        public void AddRoll(int aReturnValue)
        {
            returnValues.Add(aReturnValue);
        }

        public int Roll()
        {
            int value = returnValues[nextIndexToReturn++];

            if (nextIndexToReturn >= returnValues.Count)
            {
                nextIndexToReturn = 0;
            }

            return value;
        }
    }

    //below refactored into parameterized MockDie class
    //public class BadlyRolledDie : IRollable
    //{

    //    public int Roll()
    //    {
    //        return 5;
    //    }
    //}

    //public class WellRolledDie : IRollable
    //{

    //    public int Roll()
    //    {
    //        return 19;
    //    }
    //}

    public class Orc
    {
        private IGame game = null;
        private int health = 30;

        public Orc()
        {
            
        }

        public Orc(IGame aGame, int hitPoints)
        {
            game = aGame;
            health = hitPoints;
        }

        public void Injure(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            game.HasDied(this);
        }

        public bool IsDead()
        {
            return health <= 0;
        }
    }    

    public interface IGame
    {
        void HasDied(Orc orc);

    }
}
