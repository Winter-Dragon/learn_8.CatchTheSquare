using SFML.Graphics;
using SFML.System;

namespace Catch_The_Square
{
    class PlayerSquare : Square
    {
        private static Color shapeColor = new Color(Color.White);
        private static Vector2f rectangleShapeSizeStep = new Vector2f(10, 10);
        private static Vector2f rectangleMinShapeSize = new Vector2f(30, 30);

        private static float circleShapeSizeStep = 5f;
        private static float circleMinShapeSize = 15f;

        public PlayerSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
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
            Game.score++;

            switch (Game.choseFigure)
            {
                case "Rectangle":
                    rectangleShape.Size -= rectangleShapeSizeStep;

                    if (rectangleShape.Size.X <= rectangleMinShapeSize.X)
                    {
                        rectangleShape.Size = rectangleDefaultSize;
                    }
                    break;

                case "Circle":
                    circleShape.Radius -= circleShapeSizeStep;

                    if (circleShape.Radius <= circleMinShapeSize)
                    {
                        circleShape.Radius = circleDefaultSize;
                    }
                    break;
            }

            UpdateMovementTarget();

            switch (Game.choseFigure)
            {
                case "Rectangle":
                    rectangleShape.Position = movementTarget;
                    break;

                case "Circle":
                    circleShape.Position = movementTarget;
                    break;
            }
        }

        protected override void IncreasePlayerSquares()
        {
            switch (Game.choseFigure)
            {
                case "Rectangle":
                    rectangleShape.Size = rectangleDefaultSize;
                    break;

                case "Circle":
                    circleShape.Radius = circleDefaultSize;
                    break;
            }
        }
    }
}
