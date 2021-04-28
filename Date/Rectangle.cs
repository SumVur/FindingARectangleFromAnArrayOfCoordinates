using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingARectangleFromCoordinates.Date
{
    public class Rectangle
    {
        public Coordinate First { get; set; }
        public Coordinate Second { get; set; }
        public Coordinate Third { get; set; }
        public Coordinate Fourth { get; set; }

        public override string ToString()
        {
            return $"({First.X}:{First.Y}):({Second.X}:{Second.Y}):({Third.X}:{Third.Y}):({Fourth.X}:{Fourth.Y})";
        }
    }
}
