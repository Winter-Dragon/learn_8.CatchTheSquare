using System;
using SFML.Graphics;
using SFML.System;

namespace Catch_The_Square
{
    public class Square
    {
        protected static Vector2f rectangleDefaultSize = new Vector2f(200, 200);
        protected static float circleDefaultSize = 100f;

        protected bool isActive = true; // Флаг активности
        protected RectangleShape rectangleShape; // Форма квадрата
        protected CircleShape circleShape;
        protected float movementSpeed; // Скорость перемещения
        protected Vector2f movementTarget; // Целевая точка перемещения
        protected IntRect movementBounds; // Область перемещения

        
        public Square (Vector2f position, float movementSpeed, IntRect movementBounds)
        {
            rectangleShape = new RectangleShape(rectangleDefaultSize);
            circleShape = new CircleShape(circleDefaultSize);
            rectangleShape.Position = position;
            circleShape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movementBounds;

            UpdateMovementTarget();
        }

        public void Move()
        {
            if (isActive == false) return;

            switch (Game.choseFigure)
            {
                case "Rectangle":
                    Vector2f dir = movementTarget - rectangleShape.Position;                         // Вычислет вектор, который необходимо прибавить к квадрату, чтобы достичь цели
                    float magnitude = (float)Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);             // Нормализует вектор (X^2 + Y^2 <= 1)

                    if (magnitude <= movementSpeed)                                                 // Условие, чтобы когда скорость > оставшегося расстояния, объект не переместился дальше нужного
                    {
                        rectangleShape.Position = movementTarget;
                    }
                    else rectangleShape.Position += dir / magnitude * movementSpeed;                 // Движение объекта, когда он не в конечной точке

                    if (rectangleShape.Position == movementTarget)                                   // Если обхект достиг конечной точки - обновляет конечную точку
                    {
                        UpdateMovementTarget();

                        OnReachedTarget();
                    }
                    break;

                case "Circle":
                    Vector2f direction = movementTarget - circleShape.Position;
                    float fMagnitude = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

                    if (fMagnitude <= movementSpeed)
                    {
                        circleShape.Position = movementTarget;
                    }
                    else circleShape.Position += direction / fMagnitude * movementSpeed;

                    if (circleShape.Position == movementTarget)
                    {
                        UpdateMovementTarget();

                        OnReachedTarget();
                    }
                    break;
            }

            if (Game.bonusActionNumber == 1 && Mathf.timer == 0) DecreaseDeathSquares();
            if (Game.bonusActionNumber == 2 && Mathf.timer == 0) IncreasePlayerSquares();
        }

        public void Draw(RenderWindow win)
        {
            if (isActive == false) return;

            switch (Game.choseFigure)
            {
                case "Rectangle":
                    win.Draw(rectangleShape);
                    break;

                case "Circle":
                    win.Draw(circleShape);
                    break;
            }
        }

        public void CheckMousePosition(Vector2i mousePosition)
        {
            if (isActive == false) return;

            switch (Game.choseFigure)
            {
                case "Rectangle":
                    if (mousePosition.X > rectangleShape.Position.X && mousePosition.X < rectangleShape.Position.X + rectangleShape.Size.X &&
                    mousePosition.Y > rectangleShape.Position.Y && mousePosition.Y < rectangleShape.Position.Y + rectangleShape.Size.Y) OnClick();
                    break;

                case "Circle":
                    if (mousePosition.X > circleShape.Position.X && mousePosition.X < circleShape.Position.X + circleShape.Radius * 2 &&
                    mousePosition.Y > circleShape.Position.Y && mousePosition.Y < circleShape.Position.Y + circleShape.Radius * 2) OnClick();
                    break;
            }
        }

        protected void UpdateMovementTarget()
        {
            switch (Game.choseFigure)
            {
                case "Rectangle":
                    movementTarget.X = Mathf.rnd.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width - (int)rectangleShape.Size.X);
                    movementTarget.Y = Mathf.rnd.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height - (int)rectangleShape.Size.Y);
                    break;

                case "Circle":
                    movementTarget.X = Mathf.rnd.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width - (int)circleShape.Radius * 2);
                    movementTarget.Y = Mathf.rnd.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height - (int)circleShape.Radius * 2);
                    break;
            }
        }

        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }
        protected virtual void DecreaseDeathSquares() { }
        protected virtual void IncreasePlayerSquares() { }

    }
}
