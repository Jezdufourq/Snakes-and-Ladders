using System;
//DO NOT DELETE the two following using statements *********************************
using Game_Logic_Class;
using Object_Classes;


namespace Space_Race
{
    class Console_Class
    {
        /// <summary>
        /// Algorithm below currently plays only one game
        /// 
        /// when have this working correctly, add the abilty for the user to 
        /// play more than 1 game if they choose to do so.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            // User defined game boolean
            bool game = true;
            
            // MAIN GAME LOOP
            // While the user still wants to play a game
            while (game)
            {
                // Diplay introduction message to console
                DisplayIntroductionMessage();

                // While the number inputted to the console is not valid, keep displaying the introduction message
                while (!numberOfPlayersInput())
                {
                    DisplayIntroductionMessage();
                }

                // Waiting for the user to enter into the game
                EnterRound();
                    
                // Initilising and setting up the playing board
                Board.SetUpBoard();

                // Setting the number of players
                SpaceRaceGame.SetUpPlayers();

                // Defining a round number used to print each round
                int roundNumber = 0;

                // while the game is not over
                while (!SpaceRaceGame.GameOverCheck())
                {
                    // If the round has not finished, we need to set the round to say that it has finished
                    // The round will always be finished in the console implementation, becauase there is no single step
                    if (!SpaceRaceGame.RoundFinish)
                    {
                        SpaceRaceGame.RoundFinish = true;
                    }

                    // Main game loop implementation
                    // Print round number
                    RoundNumberPrint(roundNumber);
                    // Play one round
                    SpaceRaceGame.PlayOneRound();
                    // Display round details to console
                    DisplayPlayerRound();
                    // Wait for the user to proceed to next round
                    PressEnter();
                    roundNumber++;
                } // end game loop

                // Displaying the end game message
                DisplayEndGame();
                // Wait for user to prompt new game
                game = PromptNewGame();

                // display exit message if user doesn't want to play another game
                if (!game)
                {
                    Console.WriteLine("Thanks for playing!");
                    PressEnter();
                }
            }
        }//end Main


        /// <summary>
        /// Displaying information to the console at the end of the game.
        /// Information includes:
        ///     - Who won
        ///     - Final positions and fuel values
        /// 
        /// Pre:    none
        /// Post:   Displaying the information of the players to the console
        /// </summary>
        static void DisplayEndGame()
        {
            // Local variable to store the players who have ran out of fuel
            int counter = 0;
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                // If the game has finished, and no one is at the finishing square
                if (!SpaceRaceGame.Players[i].AtFinish)
                {
                    // then the counter is increased
                    counter++;
                }
            }

            // If counter reaches NumberOfPlayers then all players are out of fuel
            if (counter == SpaceRaceGame.NumberOfPlayers)
            {
                // The following message is printed to the console if all players have ran out of fuel
                Console.WriteLine("All players ran out of fuel before any reached the final square.");
            }
            
            // If the game has finished, printing to the console the players who have finished the game
            Console.WriteLine("\tThe following player(s) finished the game");
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                // Players who are at the finishing square
                if (SpaceRaceGame.Players[i].AtFinish)
                {
                    Console.WriteLine("\t\t{0}", SpaceRaceGame.Players[i].Name);
                    Console.WriteLine();
                }
            }

            // Printing to the console the players location
            Console.WriteLine("\tIndividual players finished at the location specified.");
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                // Printing each of the locations and fuel values
                Console.WriteLine("\t\t{0} with {1} yottawatt of power at square {2}",
                    SpaceRaceGame.Players[i].Name, SpaceRaceGame.Players[i].RocketFuel,
                    SpaceRaceGame.Players[i].Position);
            }
        }
               
        /// <summary>
        /// Display the players details at end of round
        /// Pre:    none
        /// Post:   A message is displayed to console about players current details 
        /// </summary>
        static void DisplayPlayerRound()
        {
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                Console.WriteLine("\t{0} on square {1} with {2} yottawatt of power remaining",
                    SpaceRaceGame.Players[i].Name, SpaceRaceGame.Players[i].Position, 
                    SpaceRaceGame.Players[i].RocketFuel);
            }

            Console.WriteLine();

        } //end DisplayPlayerRound

        /// <summary>
        /// Displaying the round number to the console
        /// Pre:    none.
        /// Post:   Round number is displayed to the console
        /// </summary>
        static void RoundNumberPrint(int roundNumber)
        {
            if (roundNumber == 0)
            {
                Console.WriteLine();
                Console.WriteLine("\tFirst Round\n");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\tNext Round\n");
                Console.WriteLine();
            }
        } //end RoundNumberPrint

        /// <summary>
        /// Display a welcome message to the console
        /// Pre:    none.
        /// Post:   A welcome message is displayed to the console.
        /// </summary>
        static void DisplayIntroductionMessage()
        {
            Console.WriteLine("\tWelcome to Space Race.\n" + 
                "\n" +
                "\tThis game is for 2 to 6 players.\n" +
                "\tHow many players (2-6):");
        } //end DisplayIntroductionMessage

        /// <summary>
        /// Waits for the user to enter into the round
        /// Pre:    none.
        /// Post:   The user proceeds to the first round of the game
        /// </summary>
        static void EnterRound()
        {
            Console.WriteLine("Press Enter to play a round ... ");
            Console.ReadKey();
        }//end EnterRound
        
        /// <summary>
        /// Grabs the users input for the number of players required
        /// Pre:    User enters number of players
        /// Post:   The number of players is returned
        /// </summary>
        static bool numberOfPlayersInput()
        {
            // Grabbing the users input and converting to an integer
            string numberOfPlayersStr = Console.ReadLine();
            int numberOfPlayersInt; 

            if (int.TryParse(numberOfPlayersStr, out numberOfPlayersInt))
            {
                if (numberOfPlayersInt > 6 || numberOfPlayersInt < 2)
                {
                    Console.WriteLine("Error: Invalid number of players entered.\n");
                    return false;
                }
                else
                {
                    SpaceRaceGame.NumberOfPlayers = numberOfPlayersInt;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Error: Please input an integer\n");
                return false;
            }
        }//end numberOfPlayersInput()


        /// <summary>
        /// Displays a prompt and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnter()
        {
            Console.WriteLine("Press Enter key to continue...\n");
            Console.ReadKey();
            
        } // end PressAny

        /// <summary>
        /// Used to determine if the user would like to play a new round or not
        /// 
        /// Pre: User is prompted to play another round
        /// Post: Console closes if the user doesnt want to play a new game. Game resets if user wants to play a new game.
        /// </summary>
        /// <returns>
        /// Returns a boolean variable which is determined by the user wanting to play a new round or not
        /// </returns>
        static bool PromptNewGame()
        {
            string userInput = null;

            // Prompting the user to choose a new game or not
            Console.WriteLine("Would you like to play another game? Y or N:");
            userInput = Console.ReadLine();
            
            // Conditional statement which decides if the user wants to play a new game or not
            if (userInput == "Y" || userInput == "y")
            {
                SpaceRaceGame.GameInPlay = false;
                return true;
            }
            else
            {
                return false;

            }
        }//end PromptNewGame

    }//end Console class
}
