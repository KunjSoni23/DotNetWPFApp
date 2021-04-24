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
    /// Interaction logic for BasketballPlayerWindow.xaml
    /// </summary>
    public partial class BasketballPlayerWindow : Window
    {
        //List for basketball players
        static List<BasketballPlayer> pla = new List<BasketballPlayer>();

        public BasketballPlayerWindow()
        {
            if (pla.Count == 0)
            {
                pla = new List<BasketballPlayer>() {
                new BasketballPlayer(PlayerType.BasketballPlayer,0,"LeBron James","Los Angeles Lakers",245,389,534),
                new BasketballPlayer(PlayerType.BasketballPlayer,1,"Kevin Durant","Golden State Warriors",183,289,145),
                new BasketballPlayer(PlayerType.BasketballPlayer,2,"James Harden","Houston Rockets",175,239,235),
                new BasketballPlayer(PlayerType.BasketballPlayer,3,"Anthony Davis","New Orleans Pelicans",225,245,467),
                new BasketballPlayer(PlayerType.BasketballPlayer,4,"Stephen Curry","Golden State Warriors",145,167,354)
            };
            }
            InitializeComponent();
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

        //menu Quit method -> it will close the window
        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        //it will display all the baseball player name that are stored in list
        public void Reload()
        {
            var result = from player in pla
                         select player.PlayerName;

            lstBasketballPlayers.ItemsSource = result;
        }


        //window loaded method
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Reload();

        }

        //when user click on player name it will display all the information of user to textbox

        private void lstBasketballPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstBasketballPlayers.SelectedIndex;

            var basketballPlayer = (from player in pla
                                where player.PlayerId == index
                                select player).FirstOrDefault();

            if (basketballPlayer != null)
            {
                txtBBPId.Text = basketballPlayer.PlayerId.ToString();
                txtBBPName.Text = basketballPlayer.PlayerName;
                txtBBPTeam.Text = basketballPlayer.TeamName;
                txtBBPGames.Text = basketballPlayer.GamesPlayed.ToString();
                txtBBPFieldGoals.Text = basketballPlayer.FieldsGoals.ToString();
                txtBBPThreePointers.Text = basketballPlayer.ThreePointers.ToString();
                txtBBPPoints.Text = basketballPlayer.Points().ToString();
            }
        }

        //insert method to add player in list
        private void btnBBPInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtBBPName.Text.Length == 0 || txtBBPTeam.Text.Length == 0 || txtBBPGames.Text.Length == 0 || txtBBPFieldGoals.Text.Length == 0 || txtBBPThreePointers.Text.Length == 0)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int game, fieldGoals, threePointers;
                if (Int32.TryParse(txtBBPGames.Text, out game) && Int32.TryParse(txtBBPFieldGoals.Text, out fieldGoals) && Int32.TryParse(txtBBPThreePointers.Text, out threePointers))
                {
                    BasketballPlayer p1 = new BasketballPlayer(PlayerType.BasketballPlayer, pla.Count, txtBBPName.Text, txtBBPTeam.Text, int.Parse(txtBBPGames.Text), int.Parse(txtBBPFieldGoals.Text), int.Parse(txtBBPThreePointers.Text));

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
        private void btnBBPUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lstBasketballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int game, fieldGoals, threePointers;
                if (Int32.TryParse(txtBBPGames.Text, out game) && Int32.TryParse(txtBBPFieldGoals.Text, out fieldGoals) && Int32.TryParse(txtBBPThreePointers.Text, out threePointers))
                {
                    var result = MessageBox.Show("You sure you want to update the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        int index = lstBasketballPlayers.SelectedIndex;

                        BasketballPlayer bbp = pla[index];

                        bbp.PlayerName = txtBBPName.Text;
                        bbp.TeamName = txtBBPTeam.Text;
                        bbp.GamesPlayed = int.Parse(txtBBPGames.Text);
                        bbp.FieldsGoals = int.Parse(txtBBPFieldGoals.Text);
                        bbp.ThreePointers = int.Parse(txtBBPThreePointers.Text);
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
        private void btnBBPDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstBasketballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("You sure you want to delete the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    int index = lstBasketballPlayers.SelectedIndex;
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

        //menu insert work same as insert button
        private void mnuInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtBBPName.Text.Length == 0 || txtBBPTeam.Text.Length == 0 || txtBBPGames.Text.Length == 0 || txtBBPFieldGoals.Text.Length == 0 || txtBBPThreePointers.Text.Length == 0)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int game, fieldGoals, threePointers;
                if (Int32.TryParse(txtBBPGames.Text, out game) && Int32.TryParse(txtBBPFieldGoals.Text, out fieldGoals) && Int32.TryParse(txtBBPThreePointers.Text, out threePointers))
                {
                    BasketballPlayer p1 = new BasketballPlayer(PlayerType.BasketballPlayer, pla.Count, txtBBPName.Text, txtBBPTeam.Text, int.Parse(txtBBPGames.Text), int.Parse(txtBBPFieldGoals.Text), int.Parse(txtBBPThreePointers.Text));

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
            if (lstBasketballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                int game, fieldGoals, threePointers;
                if (Int32.TryParse(txtBBPGames.Text, out game) && Int32.TryParse(txtBBPFieldGoals.Text, out fieldGoals) && Int32.TryParse(txtBBPThreePointers.Text, out threePointers))
                {
                    var result = MessageBox.Show("You sure you want to update the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        int index = lstBasketballPlayers.SelectedIndex;

                        BasketballPlayer bbp = pla[index];

                        bbp.PlayerName = txtBBPName.Text;
                        bbp.TeamName = txtBBPTeam.Text;
                        bbp.GamesPlayed = int.Parse(txtBBPGames.Text);
                        bbp.FieldsGoals = int.Parse(txtBBPFieldGoals.Text);
                        bbp.ThreePointers = int.Parse(txtBBPThreePointers.Text);
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
            if (lstBasketballPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("You sure you want to delete the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    int index = lstBasketballPlayers.SelectedIndex;
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

        //this method will carry out when user close the window.
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
