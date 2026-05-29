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
using GameOfLife.Properties;
using GameOfLife.Core;

namespace GameOfLife.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}
        //private void StartClick(object sender, RoutedEventArgs e)
        //{
        //    tbGenerations.Text = "Start clicked";
        //}
        //private void StopClick(object sender, RoutedEventArgs e)
        //{
        //    tbGenerations.Text = "Stop clicked";
        //}
        //private void ResetClick(object sender, RoutedEventArgs e)
        //{
        //    tbGenerations.Text = "Reset clicked";
        //}private Game game;
        private Border[,] cells;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            game = new Game();
            tbGridSize.Text = $"{game.Rows} x {game.Cols}";
            cells = new Border[game.Rows, game.Cols];

            CreateGameGrid();
            UpdateVisual();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            timer.Tick += TimerTick;
        }

        private void CreateGameGrid()
        {
            gameGrid.Children.Clear();
            gameGrid.Rows = game.Rows;
            gameGrid.Columns = game.Cols;
            for (int row = 0; row < game.Rows; row++)
            {
                for (int col = 0; col < game.Cols; col++)
                {
                    Border border = new Border
                    {
                        Background = Brushes.Black,
                        BorderBrush = Brushes.DimGray,
                        BorderThickness = new Thickness(0.3)
                    };

                    int capturedRow = row, capturedCol = col;
                    border.MouseLeftButtonDown += (sender, e) => CellClick(capturedRow, capturedCol);
                    cells[row, col] = border;
                    gameGrid.Children.Add(border);
                }
            }
        }

        private void CellClick(int row, int col)
        {
            if (timer.IsEnabled) return;

            game.ToggleCell(row, col);
            UpdateVisual();
        }
        private void UpdateVisual()
        {
            for (int row = 0; row < game.Rows; row++)
            {
                for (int col = 0; col < game.Cols; col++)
                {
                    if (game.Grid[row, col])
                        cells[row, col].Background = Brushes.Yellow;
                    else
                        cells[row, col].Background = Brushes.Black;
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            game.NextGeneration();
            tbGenerations.Text = $"Generation: {game.Generation}";
            UpdateVisual();
        }
        private void StartClick(object sender, RoutedEventArgs e)
        {
            int ms;
            if (!int.TryParse(tbInterval.Text, out ms))
                ms = 200;
            if (ms < 30) ms = 30;

            timer.Interval = TimeSpan.FromMilliseconds(ms);
            timer.Start();
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            game.Clear();
            tbGenerations.Text = $"Generation: {game.Generation}";
            UpdateVisual();
        }
    }
}
