using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace WpfFoodie
{
    public class Food
    {
        Ellipse circle = new Ellipse();
        int foodY = -400;
        int foodX = 0;
        Random rnd = new Random();

        public Food()
        {
            Circle.Fill = Brushes.Red;
            Circle.Width = 10;
            Circle.Height = 10;
            foodX = rnd.Next(-768, 769);
            Circle.Margin = new Thickness(foodX, FoodY, 0, 0);
            Circle = circle;
        }

        public Ellipse Circle { get => circle; set => circle = value; }
        public int FoodY { get => foodY; set => foodY = value; }
        public int FoodX { get => foodX; set => foodX = value; }
    }
}
