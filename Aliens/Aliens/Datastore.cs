namespace Aliens
{
    /// <summary>
    /// A module for keeping coordinates matrix
    /// </summary>
    public static class Datastore
    {
        /// <summary>
        /// Number of rows of datamatrix
        /// </summary>
        public static int NumberOfRows{get;set;}
        /// <summary>
        /// Number of columns of datamatrix
        /// </summary>
        public static int NumberOfColumns { get; set; }
        /// <summary>
        /// A matrix that keeps data
        /// </summary>
        public static int[,] DataMatrix { get; set; }
        /// <summary>
        /// Number hero's left lifes
        /// </summary>
        public static int NumberOfLifes { get; set; }
    }
}
