using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindingARectangleFromCoordinates.Date;

namespace FindingARectangleFromCoordinates
{
    class CoordinateSystem
    {
        public List<Rectangle> FindRectangles(IList<Coordinate> coordinates)
        {
            //Список координат Y сгруппированных по координатам X
            Dictionary<double, List<double>> ListYGroupedByX = new Dictionary<double, List<double>>();
            foreach (var item in coordinates)
            {
                if (ListYGroupedByX.ContainsKey(item.X))
                {
                    ListYGroupedByX[item.X].Add(item.Y);
                }
                else
                {
                    ListYGroupedByX.Add(item.X, new List<double>());
                    ListYGroupedByX[item.X].Add(item.Y);
                }
            }

            /*  
             foreach (var item in ListYGroupedByX)
               {
                   Console.Write(item.Key + ":[");
                   foreach (var Y in item.Value)
                   {
                       Console.Write(Y + ":");
                   }
                   Console.Write("]\n");
               }
            */

            //Создаём массив объектов типа прямоугольник куда мы будем добавлять найденные прямоугольники
            List<Rectangle> rectangles = new List<Rectangle>();


            var XCoordinate = ListYGroupedByX.Keys.ToList();
            for (int i = 0; i < XCoordinate.Count; i++)
            {
                if(i+1 < XCoordinate.Count)
                {
                    //Делаем корреляцию двух массивов Y, используя iner join
                    var SameY = (from Y1 in ListYGroupedByX[XCoordinate[i]]
                                join Y2 in ListYGroupedByX[XCoordinate[i+1]] on Y1 equals Y2
                                select Y2).ToList();


                   for (int f = 0; f < SameY.Count; f++)
            {
                for (int s = f+1; s < SameY.Count; s++)
                {
                 //Добавляем новый прямоугольник в массив
                 rectangles.Add(new Rectangle()
                    {
                        First = new Coordinate()
                        {
                            X = XCoordinate[i],
                            Y = SameY[f]
                        },
                        Second = new Coordinate()
                        {
                            X = XCoordinate[i],
                            Y = SameY[s]

                        },
                        Third = new Coordinate()
                        {
                            X = XCoordinate[i + 1],
                            Y = SameY[f]
                        },
                        Fourth = new Coordinate()
                        {
                            X = XCoordinate[i + 1],
                            Y = SameY[s]
                        },
                    }); 
                }
            }
            
                }
            }

            return rectangles;

           
        }


    }
}
