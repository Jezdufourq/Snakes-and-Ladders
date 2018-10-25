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

            /*                    
             Set up the board in Board class (Board.SetUpBoard)

            Determine number of players - initally play with 2 for testing purposes 
             Create the required players in Game Logic class
              and initialize players for start of a game             
             loop  until game is finished           
                call PlayGame in Game Logic class to play one round
                Output each player's details at end of round
             end loop
             Determine if anyone has won
             Output each player's details at end of the game
           */
            DisplayIntroductionMessage();    

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

            playerInformation();

            int roundNumber = 0;
            while (!SpaceRaceGame.gameFinish)
            {
                RoundNumberPrint(roundNumber);
                SpaceRaceGame.PlayOneRound();
                Console.WriteLine("0", SpaceRaceGame.gameFinish);
                DisplayPlayerRound();
                PressEnter();
                roundNumber++;
            } // end game loop

            // Displaying the end game message
            DisplayEndGame();

            // Wait for the user
            PressEnter();
               
            // TESTING FOR THE SET UP PLAYERS FUNCTION
            //int i = 0;
            //foreach (object a in SpaceRaceGame.Players)
            //{
            //    Console.WriteLine("Location: " + SpaceRaceGame.Players[i].Location);
            //    Console.WriteLine("Name: " + SpaceRaceGame.Players[i].Name);
            //    Console.WriteLine("HasPower: " + SpaceRaceGame.Players[i].HasPower);
            //    Console.WriteLine("Position: " + SpaceRaceGame.Players[i].Position);
            //    Console.WriteLine("RocketFuel: " + SpaceRaceGame.Players[i].RocketFuel);
            //    Console.WriteLine("AtFinish: " + SpaceRaceGame.Players[i].AtFinish + Environment.NewLine + " ");
            //    i++;
            //}
            //PressEnter();

            // TODO: Need to determine if anyone has won the game

            // TODO: Need to print the winner of the game to the console
        }//end Main


        /// <summary>
        /// Printing the player information for debugging
        ///       
        /// </summary>
        static void playerInformation()
        {

            int i = 0;
            foreach (object a in SpaceRaceGame.Players)
            {
                Console.WriteLine("Location: " + SpaceRaceGame.Players[i].Location);
                Console.WriteLine("Name: " + SpaceRaceGame.Players[i].Name);
                Console.WriteLine("HasPower: " + SpaceRaceGame.Players[i].HasPower);
                Console.WriteLine("Position: " + SpaceRaceGame.Players[i].Position);
                Console.WriteLine("RocketFuel: " + SpaceRaceGame.Players[i].RocketFuel);
                Console.WriteLine("AtFinish: " + SpaceRaceGame.Players[i].AtFinish + Environment.NewLine + " ");
                i++;
            }
        }


        /// <summary>
        /// Display the information at the end of the game
        /// Pre:    none
        /// Post:   Displaying the information of the players to the console
        /// </summary>
        static void DisplayEndGame()
        {
            Console.WriteLine("\tThe following player(s) finished the game");
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                if (SpaceRaceGame.Players[i].AtFinish)
                {
                    Console.WriteLine("\t\t{0}", SpaceRaceGame.Players[i].Name);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\tIndividual players finished at the location specified.");
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                Console.WriteLine("\t\t{0} with {1} yottawatt of power at square {2}",
                    SpaceRaceGame.Players[i].Name, SpaceRaceGame.Players[i].RocketFuel,
                    SpaceRaceGame.Players[i].Position);
            }

            Console.WriteLine();

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
        }
        
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

    }//end Console class
}
