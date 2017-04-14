using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Aliens
{
    /// <summary>
    /// A class to update datastore
    /// </summary>
    public static class Updater
    {
        /// <summary>
        /// An instance of hero object
        /// </summary>
        public static Hero MyHero = new Hero("Green", 10, 50);
        /// <summary>
        /// An instance of Alien of first type
        /// </summary>
        public static Alien Kind = new Alien("Blue", 5);
        /// <summary>
        /// An instance of Alien of second type
        /// </summary>
        public static Alien Evil = new Alien("Red", 10);
        /// <summary>
        /// indexes list to keep coordinates of first type aliens
        /// </summary>
        public static List<Point> KindAlienData;
        /// <summary>
        /// indexes list to keep coordinates of second type aliens
        /// </summary>
        public static List<Point> EvilAlienData;
        /// <summary>
        /// A function that updates hero data
        /// </summary>
        public static void UpdateHeroData()
        {
            Point current = new Point();
            current = MyHero.GetCurrent();
            int future = MyHero.GetNext(current.X);
            Datastore.DataMatrix[current.Y, current.X] = 0;
            Datastore.DataMatrix[current.Y, future] = 3;
        }
        /// <summary>
        /// A function that reads alien data
        /// </summary>
        public static void GetAliensData()
        {
            KindAlienData = new List<Point>();
            EvilAlienData = new List<Point>();
            for (int i = 0; i < Datastore.NumberOfRows; ++i)
            {
                for (int j = 0; j < Datastore.NumberOfColumns; ++j)
                {
                    // Reading data of the first type aliens
                    if (Datastore.DataMatrix[i, j] == 1)
                    {
                        Point c = new Point(j, i);
                        KindAlienData.Add(c);
                    }
                    // Reading data of the second type aliens
                    else if (Datastore.DataMatrix[i, j] == 2)
                    {
                        Point c = new Point (j, i );
                        EvilAlienData.Add(c);
                    }
                }
            }
        }
        /// <summary>
        /// A function that updates aliens data
        /// </summary>
        public static void UpdateAliensData()
        {
            GetAliensData();
            for (int i = 0; i < KindAlienData.Count(); ++i)
            {
                // Releasing an aliens previous place in datastore
                Datastore.DataMatrix[KindAlienData[i].Y, KindAlienData[i].X] = 0;
                int future = Kind.GetNext(KindAlienData[i].Y);
                if (future == Initializer.InitialPoint.Y)
                {
                    if (Datastore.DataMatrix[future, KindAlienData[i].X] == 3)
                    {
                        ++Datastore.NumberOfLifes;
                    }
                    future = 0;
                }
                // Fixing alien's new place
                Datastore.DataMatrix[future, KindAlienData[i].X] = 1;
            }
            for (int i = 0; i < EvilAlienData.Count(); ++i)
            {
                Datastore.DataMatrix[EvilAlienData[i].Y, EvilAlienData[i].X] = 0;
                int future = Evil.GetNext(EvilAlienData[i].Y);
                if (future >= Initializer.InitialPoint.Y)
                {
                    if (Datastore.DataMatrix[future, EvilAlienData[i].X] == 3)
                    {
                        --Datastore.NumberOfLifes;
                    }
                    future = 0;
                }
                Datastore.DataMatrix[future, EvilAlienData[i].X] = 2;
            }
        }
    }
}
