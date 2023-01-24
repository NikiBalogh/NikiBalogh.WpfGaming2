using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfFoodie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declare Variables
        int playerX = 3;
        int score = 0;
        int moveSpeed = 70;
        int direction = 0;
        int dropAmount = 2;
        int WhenToScale = 10;
        int countTillScale = 0;
        int DifficultyLevel = 0;
        int highscore = 0;
        List<Food> foodList = new List<Food>();
        enum Movingdirection{
            Right,
            Left
        }
        TimeSpan SpawnSpeed = new TimeSpan(30000000);
        TimeSpan DropSpeed = new TimeSpan(10000);
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = SpawnSpeed;
            timer.Start();
            timer2.Tick += new EventHandler(Timer2_Tick);
            timer2.Interval = DropSpeed;
            timer2.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Food food = new Food();
            foodList.Add(food);
            GameGrid.Children.Add(food.Circle);
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            foreach (Food food in foodList)
            {
                food.FoodY += dropAmount;
                food.Circle.Margin = new Thickness(food.FoodX, food.FoodY, 0, 0);
            }
            Scoring();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    direction = (int)Movingdirection.Right;
                    break;
                case Key.Left:
                    direction = (int)Movingdirection.Left;
                    break;
                default:
                    direction = 3;
                    break;
            }
            Move();
        }
        private void Move()
        {
            if (direction == 0)
            {
                playerX = playerX + moveSpeed;
                recPlayer.Margin = new Thickness(playerX, 403, 0, 0);
            }
            else if (direction == 1)
            {
                playerX = playerX - moveSpeed;
                recPlayer.Margin = new Thickness(playerX, 403, 0, 0);
            }
        }
        private void Scoring()
        {
            for (int j = -10; j < 10; j++)
            {
                if (foodList.Count == 0)
                {

                }
                else
                {

                    for (int i = -100; i < 100; i++)
                    {
                        if (foodList.Count == 0)
                        {
                           
                        }
                        else if (playerX + i == foodList[0].FoodX && foodList[0].FoodY == 403 + j)
                        {
                            countTillScale++;
                            score++;
                            lblScore.Content = score;
                            if (score > highscore)
                            {
                                highscore = score;
                                lblHighscore.Content = $"Highscore: {highscore}";
                            }
                            //Change index under here to number of elements on screen + 1
                            GameGrid.Children.RemoveAt(3);
                            foodList.RemoveAt(0);
                            Scaling();
                        }
                    }
                    if (foodList.Count == 0)
                    {

                    }
                    else if (foodList[0].FoodY == 403 + j)
                    {
                        //Change index under here to number of elements on screen + 1
                        GameGrid.Children.RemoveAt(3);
                        foodList.RemoveAt(0);
                        ResetScore();
                    }
                }
            }
        }
        private void Scaling()
        {
            if (countTillScale == WhenToScale)
            {
                countTillScale = 0;
                WhenToScale += 10;
                DifficultyLevel++;
                if (DifficultyLevel < 5)
                {
                    dropAmount++;
                    SpawnSpeed -= new TimeSpan(4500000);
                    timer.Interval = SpawnSpeed;
                }
            }
        }
        private void ResetScore()
        {
            countTillScale = 0;
            dropAmount = 2;
            WhenToScale = 10;
            DifficultyLevel = 0;
            SpawnSpeed = new TimeSpan(30000000);
            timer.Interval = SpawnSpeed;
            score = 0;
            lblScore.Content = score;
        }
    }
}
