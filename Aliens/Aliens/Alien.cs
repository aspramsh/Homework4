using System;

namespace Aliens
{
    /// <summary>
    /// Alien class
    /// </summary>
    public class Alien : IColorable, INextStepable
    {
        public string Color { get; set; }
        public int Speed { get; set; }
        /// <summary>
        /// Constructor to initialize
        /// </summary>
        /// <param name="color"></param>
        /// <param name="speed"></param>
        public Alien(string color, int speed)
        {
            this.Color = color;
            this.Speed = speed;
        }
        public int GetNext(int coordinate)
        {
            return Math.Min(Datastore.NumberOfColumns - 1, coordinate + this.Speed);
        }
    }
}
