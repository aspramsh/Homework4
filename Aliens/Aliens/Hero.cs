using System;
using System.Drawing;

namespace Aliens
{
    /// <summary>
    /// A hero class
    /// </summary>
    public class Hero : IColorable, INextStepable
    {
        public string Color { get; set; }
        /// <summary>
        /// health property
        /// </summary>
        public int Health { get; set; }
        public int Speed { get; set; }
        /// <summary>
        /// Enumeration to define hero's moving direction
        /// </summary>
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        };
        /// <summary>
        /// direction property
        /// </summary>
        public Direction direction { get; set; }
        /// <summary>
        /// Constructor to initialize hero object
        /// </summary>
        /// <param name="color"></param>
        /// <param name="health"></param>
        /// <param name="speed"></param>
        public Hero(string color, int health, int speed)
        {
            this.Color = color;
            this.Health = health;
            this.Speed = speed;
        }
        /// <summary>
        /// A function that returns current position of hero object
        /// </summary>
        /// <returns></returns>
        ///
        public Point GetCurrent()
        {
            // A point for keeping hero current coordinates
            Point p = new Point();
            // a loop that finds hero's current place in the datastore
            for (int i = 0; i < Datastore.NumberOfRows; ++i)
            {
                for (int j = 0; j < Datastore.NumberOfColumns; ++j)
                {
                    if (Datastore.DataMatrix[i, j] == 3)
                    {
                        p.Y = i;
                        p.X = j;
                    }
                }
            }
            return p;
        }
        /// <summary>
        /// A function that returns future position of hero object
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public int GetNext(int coordinate)
        {
            // Future position of a hero object if it moves to left
            int NextPositionLeft = Math.Max(0, coordinate - this.Speed);
            int NextPositionRight = Math.Min(Datastore.NumberOfRows - 1, coordinate + this.Speed);
            return (this.direction == Hero.Direction.Left ? NextPositionLeft : NextPositionRight);
        }
    }
}
