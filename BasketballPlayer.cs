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
    //class Basketball is inheriting from Player class.
    class BasketballPlayer : Player
    {

        //fields and getter & setter using property
        private int _fieldsGoals;

        public int FieldsGoals
        {
            get { return _fieldsGoals; }
            set { _fieldsGoals = value; }
        }

        private int _threePointers;

        public int ThreePointers
        {
            get { return _threePointers; }
            set { _threePointers = value; }
        }

        //parametrized constructor
        public BasketballPlayer(PlayerType playerType, int playerId, string playerName, string teamName, int gamesPlayed, int fieldsGoals, int threePointers) : base(playerType, playerId, playerName, teamName, gamesPlayed)
        {
            FieldsGoals = fieldsGoals;
            ThreePointers = threePointers;
        }

        //Points method
        public override int Points()
        {
            return (FieldsGoals - ThreePointers) + (2 * ThreePointers);
        }

    }
}
