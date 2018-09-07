using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class Points
    {
        public int TotalPoints { get; set; }

        public Points()
        {

        }

        public Points(int totalPoints)
        {
            TotalPoints = totalPoints;
        }

        public static Points operator + (Points point1, Points point2)
        {
            Points receivedPoints = new Points(point1.TotalPoints + point2.TotalPoints);

            return receivedPoints;
        }

        public static Points operator -(Points point1, Points point2)
        {
            Points receivedPoints = new Points(point1.TotalPoints + point2.TotalPoints);

            return receivedPoints;
        }
    }
}
