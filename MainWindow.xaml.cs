/*
Name: Soni Kunj Mayurkumar
Student ID: 991591881
Date of Submission: 25 February 2021
Topic: Midterm Exam
Guided by: Gursharan Singh Tatla
 */

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

namespace MTKunjSoni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //menu quit Click method -> it will close the window

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //menu Help method -> it will display all the information of author

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();

            about.Background = Brushes.Azure;
            about.Title = "Author Information";
            about.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            about.ShowDialog();
            //Close();
        }

        //view hockey player button to get HockeyWindows
        private void btnHockey_Click(object sender, RoutedEventArgs e)
        {
            HockeyPlayerWindow hw = new HockeyPlayerWindow();

            hw.Background = Brushes.Azure;
            hw.Title = "View Hockey Players";
            hw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            hw.ShowDialog();
        }

        //view basketball button to get BasketballWindow
        private void btnBasketball_Click(object sender, RoutedEventArgs e)
        {
            BasketballPlayerWindow bw = new BasketballPlayerWindow();

            bw.Background = Brushes.Azure;
            bw.Title = "View Basketball Players";
            bw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bw.ShowDialog();
        }

        //view baseball button to get BaseballWindow
        private void btnBaseball_Click(object sender, RoutedEventArgs e)
        {
            BaseballPlayerWindow baw = new BaseballPlayerWindow();

            baw.Background = Brushes.Azure;
            baw.Title = "View Baseball Players";
            baw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            baw.ShowDialog();
        }

        //menu to view hockey players
        private void mnuHockeyPlayers_Click(object sender, RoutedEventArgs e)
        {
            HockeyPlayerWindow hw = new HockeyPlayerWindow();

            hw.Background = Brushes.Azure;
            hw.Title = "View Hockey Players";
            hw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            hw.ShowDialog();
        }

        //menu to view basketball players
        private void mnuBasketballPlayers_Click(object sender, RoutedEventArgs e)
        {
            BasketballPlayerWindow bw = new BasketballPlayerWindow();

            bw.Background = Brushes.Azure;
            bw.Title = "View Basketball Players";
            bw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bw.ShowDialog();
        }

        //menu to view baseball players
        private void mnuBaseballPlayers_Click(object sender, RoutedEventArgs e)
        {
            BaseballPlayerWindow baw = new BaseballPlayerWindow();

            baw.Background = Brushes.Azure;
            baw.Title = "View Baseball Players";
            baw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            baw.ShowDialog();
        }

        //window closing method
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, you would like to quit?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
