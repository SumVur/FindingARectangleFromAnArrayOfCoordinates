using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FindingARectangleFromCoordinates.Date;

namespace FindingARectangleFromCoordinates.UI
{
   public class CoordinateSystemUI
    {
        public List<Coordinate> GetTestСoordinates()
        {
            return new List<Coordinate>()
            {
                new Coordinate(){ X=3, Y=10 },
                new Coordinate(){ X=4, Y=8 },
                new Coordinate(){ X=3, Y=6 },
                new Coordinate(){ X=7, Y=4 },
                new Coordinate(){ X=3, Y=0 },
                new Coordinate(){ X=2, Y=8 },
                new Coordinate(){ X=2, Y=4 },
                new Coordinate(){ X=6, Y=0 },
                new Coordinate(){ X=6, Y=3 },
                new Coordinate(){ X=-1, Y=1 },
                new Coordinate(){ X=5, Y=1 },
                new Coordinate(){ X=-1, Y=-3 },
                new Coordinate(){ X=5, Y=-3},
            };
        }
        public List<Coordinate> GetСoordinates()
        {
            Console.WriteLine("Please enter the coordinates.\n" +
                "If you want to finish entering coordinates, after entering a pair of axes you can press ecs or enter");
            string patern = @"^(-?)[0-9]{1,3}(?:[.,][0-9]{1,3})?\r?$";
            List<Coordinate> Сoordinates = new List<Coordinate>();
            do
            {
                Coordinate coordinate = new Coordinate();
                //Получаем координату  X
                coordinate.X = CoordinateInput("X", patern);

                //Получаем координату  Y
                coordinate.Y = CoordinateInput("Y", patern);

                //Добавляем координаты в массив координат
                Сoordinates.Add(coordinate);
                Console.WriteLine("Esc or Enter");
                if(Console.ReadKey().Key==ConsoleKey.Escape)
                {
                    break;
                }
                

            } while (true);
            return Сoordinates;
        }
        private double CoordinateInput(string CoordinateName,string patern)
        {
            //Ввод координаты 
            do
            {
                Console.WriteLine(CoordinateName+":");
                string chars = Console.ReadLine();
                // Проверяем введённые данный, методом сопоставления с регулярным выражением

                if (Regex.IsMatch(chars, patern))
                {
                    //Возвращаем координату
                    return  double.Parse(chars);
                }
                else
                {
                    //В случае если  данные были введены некорректно просим ввести ещё раз
                }

            } while (true);
        }

        public void ShowInformationRectangles(List<Rectangle> rectangles, List<Coordinate> coordinates)
        {
            ShowСoordinates(coordinates);
            Console.WriteLine($"From this set of coordinates, you can get -{rectangles.Count} rectangles"); 
            foreach (var rectangle in rectangles)
            {
                Console.WriteLine(rectangle.ToString());
            }
        }
        public void ShowСoordinates(List<Coordinate> coordinates)
        {
            Console.WriteLine("Array of coordinates");
            foreach (var Coordinate in coordinates)
            {
                Console.Write($"({Coordinate.X}:{Coordinate.Y});");
            }
            Console.WriteLine("\n");
        }
    }
}
