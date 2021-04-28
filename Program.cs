using FindingARectangleFromCoordinates.Date;
using FindingARectangleFromCoordinates.UI;
using System;
using System.Collections.Generic;

namespace FindingARectangleFromCoordinates
{
    class Program
    {
        static void Main(string[] args)
        {
            CoordinateSystemUI UI = new CoordinateSystemUI();
            List<Coordinate> coordinates = UI.GetTestСoordinates();
            UI.ShowInformationRectangles(new CoordinateSystem().FindRectangles(coordinates), coordinates);
        }
    }
}
