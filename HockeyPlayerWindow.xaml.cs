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
    /// Interaction logic for HockeyPlayerWindow.xaml
    /// </summary>
    public partial class HockeyPlayerWindow : Window
    {
        
        //list to store hockey player
        static List<HockeyPlayer> pla = new List<HockeyPlayer>();

        public HockeyPlayerWindow()
        {
            if (pla.Count == 0)
            {
                pla = new List<HockeyPlayer>() {

                new HockeyPlayer(PlayerType.HockeyPlayer,0,"Per Djoos","Red Wings",153,234,456),
                new HockeyPlayer(PlayerType.HockeyPlayer,1,"Jeff Beukeboom","Oilers",146,334,326),
                new HockeyPlayer(PlayerType.HockeyPlayer,2,"Hakan Loob","Red Wings",135,244,546),
                new HockeyPlayer(PlayerType.HockeyPlayer,3,"Zarley Zalapski","Rangers",123,534,256),
                new HockeyPlayer(PlayerType.HockeyPlayer,4,"Garth Butcher","Blues",134,134,286)
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

            lstHockeyPlayers.ItemsSource = result;
        }

        //window loaded method

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        //when user click on player name it will display all the information of user to textbox

        private void lstHockeyPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstHockeyPlayers.SelectedIndex;

            var hockeyPlayer = (from player in pla
                               where player.PlayerId == index && player.PlayerType == PlayerType.HockeyPlayer
                               select player).FirstOrDefault();

            if (hockeyPlayer != null)
            {
                txtHPID.Text = hockeyPlayer.PlayerId.ToString();
                txtHPName.Text = hockeyPlayer.PlayerName;
                txtHPTeam.Text = hockeyPlayer.TeamName;
                txtHPGames.Text = hockeyPlayer.GamesPlayed.ToString();
                txtHPAssists.Text = hockeyPlayer.Assists.ToString();
                txtHPGoals.Text = hockeyPlayer.Goals.ToString();
                txtHPPoints.Text = hockeyPlayer.Points().ToString();
            }


        }

        //insert method to add player in list

        private void btnHPInsert_Click(object sender, RoutedEventArgs e)
        {
            if(txtHPName.Text.Length == 0  || txtHPTeam.Text.Length == 0 || txtHPGames.Text.Length == 0|| txtHPAssists.Text.Length == 0 || txtHPGoals.Text.Length == 0)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int game, assist, goal;
                if (Int32.TryParse(txtHPGames.Text, out game) && Int32.TryParse(txtHPAssists.Text, out assist) && Int32.TryParse(txtHPGoals.Text, out goal))
                {
                    HockeyPlayer p1 = new HockeyPlayer(PlayerType.HockeyPlayer, pla.Count, txtHPName.Text, txtHPTeam.Text, int.Parse(txtHPGames.Text), int.Parse(txtHPAssists.Text), int.Parse(txtHPGoals.Text));

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

        private void btnHPUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lstHockeyPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                int game, assist, goal;
                if (Int32.TryParse(txtHPGames.Text, out game) && Int32.TryParse(txtHPGames.Text, out assist) && Int32.TryParse(txtHPGames.Text, out goal))
                {
                    var result = MessageBox.Show("You sure you want to update the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        int index = lstHockeyPlayers.SelectedIndex;

                        HockeyPlayer hp = pla[index];

                        hp.PlayerName = txtHPName.Text;
                        hp.TeamName = txtHPTeam.Text;
                        hp.GamesPlayed = int.Parse(txtHPGames.Text);
                        hp.Assists = int.Parse(txtHPAssists.Text);
                        hp.Goals = int.Parse(txtHPGoals.Text);
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

        private void btnHPDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstHockeyPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("You sure you want to delete the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (result == MessageBoxResult.Yes)
                {
                    int index = lstHockeyPlayers.SelectedIndex;

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
            if (txtHPName.Text.Length == 0 || txtHPTeam.Text.Length == 0 || txtHPGames.Text.Length == 0 || txtHPAssists.Text.Length == 0 || txtHPGoals.Text.Length == 0)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                int game, assist, goal;
                if (Int32.TryParse(txtHPGames.Text, out game) && Int32.TryParse(txtHPAssists.Text, out assist) && Int32.TryParse(txtHPGoals.Text, out goal))
                {
                    HockeyPlayer p1 = new HockeyPlayer(PlayerType.HockeyPlayer, pla.Count, txtHPName.Text, txtHPTeam.Text, int.Parse(txtHPGames.Text), int.Parse(txtHPAssists.Text), int.Parse(txtHPGoals.Text));

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
            if (lstHockeyPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                int game, assist, goal;
                if (Int32.TryParse(txtHPGames.Text, out game) && Int32.TryParse(txtHPGames.Text, out assist) && Int32.TryParse(txtHPGames.Text, out goal))
                {
                    var result = MessageBox.Show("You sure you want to update the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        int index = lstHockeyPlayers.SelectedIndex;

                        HockeyPlayer hp = pla[index];

                        hp.PlayerName = txtHPName.Text;
                        hp.TeamName = txtHPTeam.Text;
                        hp.GamesPlayed = int.Parse(txtHPGames.Text);
                        hp.Assists = int.Parse(txtHPAssists.Text);
                        hp.Goals = int.Parse(txtHPGoals.Text);
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
            if (lstHockeyPlayers.SelectedItem == null)
            {
                MessageBox.Show("Please select the player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("You sure you want to delete the players? ", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (result == MessageBoxResult.Yes)
                {
                    int index = lstHockeyPlayers.SelectedIndex;

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
