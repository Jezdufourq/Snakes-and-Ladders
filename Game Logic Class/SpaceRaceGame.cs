using System.Drawing;
using System.ComponentModel;
using Object_Classes;


namespace Game_Logic_Class
{
    public static class SpaceRaceGame
    {
        // Minimum and maximum number of players.
        public const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;

        // This variable determines if the game has finished or not
        public static bool gameFinish = false;

        public static bool roundFinish = false;

        public static bool resetPlayers = false;

        private static int numberOfPlayers;  //default value for test purposes only 
        public static int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            set
            {
                numberOfPlayers = value;
            }
        }

        public static string[] names = { "One", "Two", "Three", "Four", "Five", "Six" };  // default values

        // Only used in Part B - GUI Implementation, the colours of each player's token
        private static Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Yellow, Brushes.Red,
                                                                       Brushes.Orange, Brushes.White,
                                                                      Brushes.Green, Brushes.DarkViolet};
        public static BindingList<Player> Players { get; } = new BindingList<Player>();

        // The pair of die
        private static Die die1 = new Die(), die2 = new Die();


        /// <summary>
        /// Set up the conditions for this game as well as
        ///   creating the required number of players, adding each player 
        ///   to the Binding List and initialize the player's instance variables
        ///   except for playerTokenColour and playerTokenImage in Console implementation.
        ///   
        ///     
        /// Pre:  none
        /// Post:  required number of players have been initialsed for start of a game.
        /// </summary>
        public static void SetUpPlayers()
        {
            Players.Clear();

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Players.Add(new Player(names[i])
                {
                    Position = 0,
                    RocketFuel = Player.INITIAL_FUEL_AMOUNT,
                    HasPower = true,
                    AtFinish = false,
                    Location = Board.StartSquare,
                    PlayerTokenColour = playerTokenColours[i]
                });
            }
        }// end SetUpPlayers

        /// <summary>
        /// Plays one round of the game for all player objects. 
        /// Uses the PlayOneRoundSinglePlayer method for each of the player objects in the Players binding list
        /// Pre: Players are initialised as per their previous position
        /// 
        /// Post: Players positions and fuel amount are updated accordinly with respect to the dice roll
        /// </summary>
        public static void PlayOneRound()
        {
            // Foreach of the player objects in the Players binding list
            // Play one round of the game updating the player object
            // Check if the game is over
            foreach (Player playerObject in Players)
            {
                PlayOneRoundSinglePlayer(playerObject);
            }
        }// end PlayOneRound


        /// <summary>
        /// Plays one round for a single player object.
        /// In this implementation, the player object is stored in a binding list. 
        /// One round is played by rolling the two dice, and updating the player object attributes according.
        /// Game over conditions are checked to see when the game has finished.
        /// 
        /// </summary>
        /// <param name="player"> Player object passed as a parameter. Used for step implementation.</param>
        public static void PlayOneRoundSinglePlayer(Player player)
        {
            // If the player has power, proceed with the round
            if (player.HasPower)
            {
                // Roll the two dice, and update the players attributed accordingly
                player.Play(die1, die2);
                // Check the game over condition
                GameOverCheck();
            }
        }// end PlayOneRoundSinglePlayer


        /// <summary>
        /// This method checks if the game is over based on the attributes of each of the player objects in the Players binding list.
        /// If the player is at the finish, and the round is over, then game is ended.
        /// If the player has no power, and the round is finished, then the game is ended
        ///
        /// Pre: The game has not ended, conditions have not been met
        /// Post: The game is ended, the user need to reset the game to play again
        /// </summary>
        public static bool GameOverCheck()
        {
            // Looping through each of the player objects in the Players binding list
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                // Condition to check if the player is at the end square, and round is finished
                if (Players[i].AtFinish && roundFinish)
                {
                    return true;
                }

                // condition to check if the player has no fuel, and the round is finished
                else if (!Players[i].HasPower && roundFinish)
                {
                    return true;
                }
            }
            // Return false if the game has not ended
            return false;
        }//end GameOverCheck

    }//end SnakesAndLadders
}