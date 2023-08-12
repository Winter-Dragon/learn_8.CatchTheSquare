using SFML.Graphics;
using SFML.System;

namespace Catch_The_Square
{
    class BonusSquare : Square
    {
        private static Color shapeColor = new Color(Color.Magenta);
        private static Vector2f rectangleMinShapeSize = new Vector2f(50, 50);
        private static Vector2f rectangleShapeSizeStep = new Vector2f(10, 10);
        private static float minMovementSpeed = 5f;

        private static float circleMinShapeSize = 25f;
        private static float circleShapeSizeStep = 5f;

        public BonusSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, 30, movementBounds)
        {
            switch (Game.choseFigure)
            {
                case "Rectangle":
                    rectangleShape.FillColor = shapeColor;
                    break;

                case "Circle":
                    circleShape.FillColor = shapeColor;
                    break;
            }
        }

        protected override void OnClick()
        {
            Game.bonusActionNumber = Mathf.rnd.Next(1, 3);
            Game.bonusSquareIsClicked = true;
            Mathf.timer = 0;
            Game.score += 5;
        }

        protected override void OnReachedTarget()
        {
            switch (Game.choseFigure)
            {
                case "Rectangle":
                    if (rectangleShape.Size.X > rectangleMinShapeSize.X) rectangleShape.Size -= rectangleShapeSizeStep;
                    break;

                case "Circle":
                    if (circleShape.Radius > circleMinShapeSize) circleShape.Radius -= circleShapeSizeStep;
                    break;
            }

            if (movementSpeed > minMovementSpeed) movementSpeed--;
        }
    }
}   
