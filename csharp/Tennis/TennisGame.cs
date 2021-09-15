
namespace Tennis
{
    /// <summary>
    /// This Class is used to progress a game of tennis between two players
    /// <para>09/15/21    DJB     Original</para>
    /// </summary>
    class TennisGame : ITennisGame
    {

        #region Private_Members
        /// <summary>
        /// This contains all of the relavent information about this player.
        /// <para>09/15/21    DJB     Original</para>
        /// </summary>
        private struct StPlayer
        {
            public int iPlayerScore   =0;            
            public string sName         = string.empty;
        }

        
        private StPlayer stPlayer1 = new StPlayer();
        private StPlayer stPlayer2 = new StPlayer();
        #endregion //Private_Members


        #region Public_Methods

        /// <summary>
        /// Constructor that initializes this TennisGame instance. Excepts two Player names as arguments.
        /// <para>09/15/21    DJB     Original</para>
        /// </summary>
        public TennisGame(string sPlayer1Name, string sPlayer2Name)
        {
            stPlayer1.sName = sPlayer1Name;
            stPlayer2.sName = sPlayer2Name;
        }


        /// <summary>
        /// Method: Awards points to the player that matches the sPlayerName
        /// <para>09/15/21    DJB     Original</para>
        /// </summary>
        public void WonPoint(string sPlayerName)
        {

            switch(sPlayerName)
            {
                case stPlayer1.sName:
                    stPlayer1.iPlayerScore++;
                    break;
                case stPlayer2.sName:
                    stPlayer2.iPlayerScore++;
                    break;
                default:
                    //the name doesnt match a registered player no score tally is increased.
                    break;
            }
        }


        /// <summary>
        /// Returns the score value in tennis definitions.
        /// <para>09/15/21    DJB     Original</para>
        /// </summary>
        public string GetScore()
        {
            int iTempScore;
            string sScore = "";

            if (stPlayer1.iPlayerScore == stPlayer2.iPlayerScore)
            {
                sScore = ReturnTiedScore(stPlayer1.iPlayerScore);
            }
            else if ((stPlayer1.iPlayerScore >= 4) || (stPlayer2.iPlayerScore >= 4)) 
            {
                var minusResult = stPlayer1.iPlayerScore - stPlayer2.iPlayerScore;

                if(Math.Abs(minusResult)==1)
                {
                    sScore = "Advantage player"+ ReturnPlayersNumberWithTheHigherScore();
                }
                else if(Math.Abs(minusResult)>2)
                {
                    sScore = "Win for player" + ReturnPlayersNumberWithTheHigherScore();
                }
            }
            else //no one has reached above 3 points
            {

                for (int i = 1; i < 3; i++)
                {
                    switch(i)
                    {
                        case 1:
                            iTempScore = stPlayer1.iPlayerScore;
                            break;
                        case 2:
                            sScore += "-";
                            iTempScore = stPlayer2.iPlayerScore;
                            break;
                    }

                    switch (iTempScore)
                    {
                        case 0:
                            sScore += "Love";
                            break;
                        case 1:
                            sScore += "Fifteen";
                            break;
                        case 2:
                            sScore += "Thirty";
                            break;
                        case 3:
                            sScore += "Forty";
                            break;
                    }
                }
            }
            return sScore;
        }

        #endregion //Public_Methods


        #region Private_Methods

        /// <summary>
        /// If the Score is tied, return the proper terminology.
        /// <para>09/15/21    DJB     Original</para>
        /// </summary>
        private string ReturnTiedScore(int iLocalScore)
        {
            switch (iLocalScore)
            {
                case 0:
                    return ("Love-All");
                case 1:
                    return ("Fifteen-All");
                case 2:
                    return ("Thirty-All");
                    break;
                default:
                    return ("Deuce");
            }
        }

        /// <summary>
        /// Compares the scores of player 1 and 2 and determines which one has more points.
        /// <para>09/15/21    DJB     Original</para>
        /// </summary>
        private string ReturnPlayersNumberWithTheHigherScore()
        {
            if(stPlayer1.iPlayerScore>stPlayer2.iPlayerScore)
            {
                return ("1");   //represents player 1
            }
            else
            {
                return ("2");   //represents player 2
            }

            return (string.empty);
        }

        #endregion //Private_Methods
    }
}

