using SFML.Graphics;
using SFML.System;

namespace Catch_The_Square
{
    class DeathSquare : Square
    {
        private static Color shapeColor = new Color(Color.Red);
        private static float maxMovementSpeed = 10f;
        private static float movementStep = 0.1f;
        private static Vector2f rectangleMaxShapeSize = new Vector2f(300, 300);
        private static Vector2f rectangleShapeSizeStep = new Vector2f(10, 10);
        private static Vector2f rectangleMinShapeSize = new Vector2f(100, 100);

        private static float circleMaxShapeSize = 150f;
        private static float circleShapeSizeStep = 5f;
        private static float circleMinShapeSize = 50f;

        public DeathSquare (Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
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
            Game.isLose = true;
        }

        protected override void OnReachedTarget()
        {
            if (movementSpeed < maxMovementSpeed) movementSpeed += movementStep;

            switch (Game.choseFigure)
            {
                case "Rectangle":
                    if (rectangleShape.Size.X < rectangleMaxShapeSize.X) rectangleShape.Size += rectangleShapeSizeStep;
                    break;

                case "Circle":
                    if (circleShape.Radius < circleMaxShapeSize) circleShape.Radius += circleShapeSizeStep;
                    break;
            }
        }

        protected override void DecreaseDeathSquares()
        {
            switch (Game.choseFigure)
            {
                case "Rectangle":
                    rectangleShape.Size = rectangleMinShapeSize;
                    break;

                case "Circle":
                    circleShape.Radius = circleMinShapeSize;
                    break;
            }
        }
    }
}
