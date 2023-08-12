using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Catch_The_Square
{
    public class SquaresList
    {
        private List<Square> squares;
        public bool bonusSquareIsActive = false;

        public SquaresList()
        {
            squares = new List<Square>(6);
        }

        public void UpdateStateSquares(RenderWindow window)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(window));
                }
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(window);
            }
        }

        public void AddPlayerSquare()
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.rnd.Next(0, 1400), Mathf.rnd.Next(0, 700)), 10f, new IntRect(0, 0, 1600, 900)));
        }

        public void AddDeathSquare()
        {
            squares.Add(new DeathSquare(new Vector2f(Mathf.rnd.Next(0, 1400), Mathf.rnd.Next(0, 700)), 5f, new IntRect(0, 0, 1600, 900)));
        }

        public void AddBonusSquare()
        {
            if (bonusSquareIsActive == false)
            {
                squares.Add(new BonusSquare(new Vector2f(Mathf.rnd.Next(0, 1400), Mathf.rnd.Next(0, 700)), 5f, new IntRect(0, 0, 1600, 900)));

                bonusSquareIsActive = true;
            }
        }

        public void Reset()
        {
            squares.Clear();
        }

        public void DeleteBonusSquare()
        {
            squares.RemoveAt(5);
        }
    }
}
