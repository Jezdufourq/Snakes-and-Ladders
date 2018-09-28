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

        private static int numberOfPlayers = 2;  //default value for test purposes only 
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
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Players.Add(new Player(names[i])
                {
                    Position = 0,
                    RocketFuel = Player.INITIAL_FUEL_AMOUNT,
                    HasPower = false,
                    AtFinish = false,
                });
        }
        }

        /// <summary>
        ///  Plays one round of a game
        /// </summary>
        public static void PlayOneRound()
        {
            // Creating a loop to loop through all of the players
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Players[i].Play(die1, die2);
            }
        }

    }//end SnakesAndLadders
}