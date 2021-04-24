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

namespace MTKunjSoni
{
    //enum for PlayerType
    public enum PlayerType
    {
        HockeyPlayer, BasketballPlayer, BaseballPlayer
    }

    //abstract class
    abstract class Player
    {

        //fields and getter and setter using property
        private PlayerType _playerType;

        public PlayerType PlayerType
        {
            get { return _playerType; }
            set { _playerType = value; }
        }


        private int _playerId;

        public int PlayerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }

        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        private int _gamesPlayed;

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set
            {
                _gamesPlayed = value;
            }
        }

        //paramter constructor
        public Player(PlayerType playerType, int playerId, string playerName, string teamName, int gamesPlayed)
        {
            PlayerType = playerType;
            PlayerId = playerId;
            PlayerName = playerName;
            TeamName = teamName;
            GamesPlayed = gamesPlayed;

        }

        //Points abstract method.
        public abstract int Points();

    }
}
