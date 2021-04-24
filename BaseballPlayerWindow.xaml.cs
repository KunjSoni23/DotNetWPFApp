/*
Name: Soni Kunj Mayurkumar
Student ID: 991591881
Date of Submission: 25 February 2021
Topic: Midterm Exam
Guided by: Gursharan Singh Tatla
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace MTKunjSoni
{
    /// <summary>
    /// Interaction logic for BaseballPlayerWindow.xaml
    /// </summary>
    public partial class BaseballPlayerWindow : Window
    {
        //BaseballPlayer List to store baseball player
        static List<BaseballPlayer> pla = new List<BaseballPlayer>();

        public BaseballPlayerWindow()
        {
            if (pla.Count == 0)
            {
                pla = new List<BaseballPlayer>() {

                    new BaseballPlayer(PlayerType.BaseballPlayer,0,"Willie Mays","New York Yankees",231,354,211),
                    new BaseballPlayer(PlayerType.BaseballPlayer,1,"Hank Aaron","Boston Red Sox",231,354,211),
                    new BaseballPlayer(PlayerType.BaseballPlayer,2,"Ted Williams","Los Angeles Dodgers",231,354,211),
                    new BaseballPlayer(PlayerType.BaseballPlayer,3,"Ty Cobb","Chicago Cubs",231,354,211),
                    new BaseballPlayer(PlayerType.BaseballPlayer,4,"Joe DiMaggio","St Louis Cardinals",231,354,211)
            };
            }

            InitializeComponent();
        }
        //menu Quit method -> it will close the window

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
        }

        //it will display all the baseball player name that are stored in list

        public void Reload()
        {
            var result = from player in pla
                         select player.PlayerName;

            lstBaseballPlayers.ItemsSource = result;
        }

        //window loaded method

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();

        }

        //when user click on player name it will display all the information of user to textbox

        private void lstBaseballPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstBaseballPlayers.SelectedIndex;

            var baseballPlayer = (from player in pla
                                    where player.PlayerId == index
                                    select player).FirstOrDefault();

            if (baseballPlayer != null)
            {
                txtBPId.Text = baseballPlayer.PlayerId.ToString();
                txtBPName.Text = baseballPlayer.PlayerName;
                txtBPTeam.Text = baseballPlayer.TeamName;
                txtBPGames.Text = baseballPlayer.GamesPlayed.ToString();
                txtBPRuns.Text = baseballPlayer.Runs.ToString();
                txtBPHomeRuns.Text = baseballPlayer.HomeRuns.ToString();
                txtBPPoints.Text = baseballPlayer.Points().ToString();
            }
        }

        //menu insert work same as insert button

        private void mnuInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtBPName.Text.Length == 0 || txtBPTeam.Text.Length == 0 || txtBPGames.Text.Length == 0 || txtBPRuns.Text.Length == 0 || txtBPHomeRuns.Text.Length == 0)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int game, runs, homeRuns;
                if (Int32.TryParse(txtBPGames.Text, out game) && Int32.TryParse(txtBPRuns.Text, out runs) && Int32.TryParse(txtBPHomeRuns.Text, out homeRuns))
                {
                    BaseballPlayer p1 = new BaseballPlayer(PlayerType.BaseballPlayer, pla.Count, txtBPName.Text, txtBPTeam.Text, int.Parse(txtBPGames.Text), int.Parse(txtBPRuns.Text), int.Parse(txtBPHomeRuns.Text));

                    pla.Add(p1);
                }
                else
                {
                    MessageBox.Show("Invalid Input! Please try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Reload();
        }

        //menu update work same as update button

        private void mnuUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (lstBaseballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int game, runs, homeRuns;
                if (Int32.TryParse(txtBPGames.Text, out game) && Int32.TryParse(txtBPRuns.Text, out runs) && Int32.TryParse(txtBPHomeRuns.Text, out homeRuns))
                {
                    var result = MessageBox.Show("You sure you want to update the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {

                        int index = lstBaseballPlayers.SelectedIndex;

                        BaseballPlayer bp = pla[index];

                        bp.PlayerName = txtBPName.Text;
                        bp.TeamName = txtBPTeam.Text;
                        bp.GamesPlayed = int.Parse(txtBPGames.Text);
                        bp.Runs = int.Parse(txtBPRuns.Text);
                        bp.HomeRuns = int.Parse(txtBPHomeRuns.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input! Please try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Reload();
        }

        //menu delete work same as delete button
        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstBaseballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("You sure you want to delete the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    int index = lstBaseballPlayers.SelectedIndex;
                    if (index >= 0)
                    {
                        pla.RemoveAt(index);

                    }

                    for (int i = 0; i < pla.Count; i++)
                    {
                        pla[i].PlayerId = i;
                    }
                }
            }
            Reload();
        }

        //insert method to add player in list

        private void btnBPInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtBPName.Text.Length == 0 || txtBPTeam.Text.Length == 0 || txtBPGames.Text.Length == 0 || txtBPRuns.Text.Length == 0 || txtBPHomeRuns.Text.Length == 0)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int game, runs, homeRuns;
                if (Int32.TryParse(txtBPGames.Text, out game) && Int32.TryParse(txtBPRuns.Text, out runs) && Int32.TryParse(txtBPHomeRuns.Text, out homeRuns))
                {
                    BaseballPlayer p1 = new BaseballPlayer(PlayerType.BaseballPlayer, pla.Count, txtBPName.Text, txtBPTeam.Text, int.Parse(txtBPGames.Text), int.Parse(txtBPRuns.Text), int.Parse(txtBPHomeRuns.Text));

                    pla.Add(p1);
                }
                else
                {
                    MessageBox.Show("Invalid Input! Please try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Reload();
        }

        //update button to update the player information in list

        private void btnBPUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (lstBaseballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int game, runs, homeRuns;
                if (Int32.TryParse(txtBPGames.Text, out game) && Int32.TryParse(txtBPRuns.Text, out runs) && Int32.TryParse(txtBPHomeRuns.Text, out homeRuns))
                {
                    var result = MessageBox.Show("You sure you want to update the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {

                        int index = lstBaseballPlayers.SelectedIndex;

                        BaseballPlayer bp = pla[index];

                        bp.PlayerName = txtBPName.Text;
                        bp.TeamName = txtBPTeam.Text;
                        bp.GamesPlayed = int.Parse(txtBPGames.Text);
                        bp.Runs = int.Parse(txtBPRuns.Text);
                        bp.HomeRuns = int.Parse(txtBPHomeRuns.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input! Please try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Reload();
        }

        //delete button to delete the player from the list
        private void btnBPDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstBaseballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("You sure you want to delete the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    int index = lstBaseballPlayers.SelectedIndex;
                    if (index >= 0)
                    {
                        pla.RemoveAt(index);

                    }

                    for (int i = 0; i < pla.Count; i++)
                    {
                        pla[i].PlayerId = i;
                    }
                }
            }
            Reload();
        }

        //window closing
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
