using System.Drawing;

namespace Aliens
{
    /// <summary>
    /// A module that initializes datastore
    /// </summary>
    public static class Initializer
    {
        public static Point InitialPoint = new Point();
        public static void InitializeDatastore()
        {
            Datastore.NumberOfRows = 300;
            Datastore.NumberOfColumns = 300;
            Datastore.NumberOfLifes = 10;
            Datastore.DataMatrix = new int[Datastore.NumberOfRows, Datastore.NumberOfColumns];
            // initializing aliens coordinates
            for (int i = 0; i < Datastore.NumberOfColumns; i += 50)
            {
                if (i % 100 == 0)
                {
                    Datastore.DataMatrix[0, i] = 1;
                }
                else
                    Datastore.DataMatrix[0, i] = 2;
            }
            // Initializing hero coordinates
            Datastore.DataMatrix[250, 100] = 3;
            InitialPoint.Y = 250;
            InitialPoint.X = 100;
        }
    }
}
