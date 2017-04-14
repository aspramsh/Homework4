namespace Aliens
{
    /// <summary>
    /// An interface for the functionality of moving to the next position
    /// </summary>
    interface INextStepable
    {
        /// <summary>
        /// A speed property
        /// </summary>
        int Speed { get; set;}
        /// <summary>
        /// A function that returns the future position
        /// </summary>
        /// <returns></returns>
        int GetNext(int coordinate);
    }
}
