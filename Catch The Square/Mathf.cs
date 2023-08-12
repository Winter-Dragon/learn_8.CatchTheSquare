using System;

namespace Catch_The_Square
{
    public static class Mathf
    {
        static public Random rnd = new Random();
        static public float timer;

        static public void AddBonusSquare()
        {
            if (Mathf.rnd.Next(0, Game.bonusFrequency * 60) == 0 && Game.bonusIsActive == false)
            {
                Game.bonusIsActive = true;
            }
        }
    }
}
