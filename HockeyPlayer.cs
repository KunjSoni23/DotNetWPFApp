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
    //Class HockeyPlayer is innheriting from Player class
    class HockeyPlayer : Player
    {
        //fields and getter & setter using property
        private int _assists;

        public int Assists
        {
            get { return _assists; }
            set { _assists = value; }
        }

        private int _goals;

        public int Goals
        {
            get { return _goals; }
            set { _goals = value; }
        }

        //parametrized constructor
        public HockeyPlayer(PlayerType playerType, int playerId, string playerName, string teamName, int gamesPlayed, int assists, int goals) : base(playerType, playerId, playerName, teamName, gamesPlayed)
        {
            Assists = assists;
            Goals = goals;
        }

        //Points method
        public override int Points()
        {
            return Assists + (2 * Goals);
        }

    }
}
