using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Catch_The_Square
{
    public class Game
    {
        public static int bonusFrequency = 20;                  // Частота появления бонуса в секундах

        private SquaresList squaresList;
        public static int score = 0;
        public static int highScore = score;
        public static bool isLose = false;
        public static bool bonusIsActive = false;
        public static bool bonusSquareIsClicked = false;
        public static int bonusActionNumber;
        public static bool gameIsStart = false;
        public static string choseFigure;

        private Font mainFont = new Font("Caveat-Regular.ttf");
        private Text scoreText;
        private Text loseText;
        private Text startText;

        public Game()
        {
            squaresList = new SquaresList();

            ResetGame();

            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = new Color(0, 200, 0);
            scoreText.CharacterSize = 40;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = new Color(0, 200, 0);
            loseText.CharacterSize = 70;
            loseText.Position = new Vector2f(300, 400);

            startText = new Text();
            startText.Font = mainFont;
            startText.FillColor = new Color(0, 200, 0);
            startText.CharacterSize = 70;
            startText.Position = new Vector2f(600, 300);
        }

        private void ResetGame()
        {
            isLose = false;
            squaresList.Reset();

            if (highScore < score) highScore = score;
            score = 0;

            for (int i = 0; i < 3; i++)
            {
                squaresList.AddPlayerSquare();
            }
            for (int i = 0; i < 2; i++)
            {
                squaresList.AddDeathSquare();
            }
        }

        public void Update(RenderWindow window)
        {
            if (isLose == false && gameIsStart == true)
            {
                squaresList.UpdateStateSquares(window);

                Mathf.AddBonusSquare();

                if (bonusIsActive == true)
                {
                    squaresList.AddBonusSquare();
                }

                if (bonusSquareIsClicked == true)
                {
                    squaresList.DeleteBonusSquare();

                    bonusSquareIsClicked = false;
                    bonusIsActive = false;
                    squaresList.bonusSquareIsActive = false;
                }

                Mathf.timer += 0.016f;
            }
            
            if (isLose == true)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    ResetGame();
                }

                loseText.DisplayedString = "DEFEAT! Press \"Spacebar\" to restart :)";
                window.Draw(loseText);
            }

            if (gameIsStart == false)
            {
                startText.DisplayedString = "Choose a figure: \n\n" + "\"1\" - Rectangle \n" + "\"2\" - Circle";
                window.Draw(startText);

                if (Keyboard.IsKeyPressed(Keyboard.Key.Num1))
                {
                    gameIsStart = true;
                    choseFigure = "Rectangle";
                    ResetGame();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Num2))
                {
                    gameIsStart = true;
                    choseFigure = "Circle";
                    ResetGame();
                }
            }

            scoreText.DisplayedString = "Score: " + score.ToString() + "\n" + "Highscore: " + highScore.ToString();
            window.Draw(scoreText);
        }
    }
}
