using System;
//  Uncomment  this using statement after you have remove the large Block Comment below 
using System.Drawing;
using System.Windows.Forms;
using Game_Logic_Class;
//  Uncomment  this using statement when you declare any object from Object Classes, eg Board,Square etc.
using Object_Classes;

namespace GUI_Class
{
    public partial class SpaceRaceForm : Form
    {
        // The numbers of rows and columns on the screen.
        const int NUM_OF_ROWS = 7;
        const int NUM_OF_COLUMNS = 8;

        // For single play implementation
        private int currentPlayer = 0;

        // When we update what's on the screen, we show the movement of a player 
        // by removing them from their old square and adding them to their new square.
        // This enum makes it clear that we need to do both.
        enum TypeOfGuiUpdate { AddPlayer, RemovePlayer };

        /// <summary>
        /// Implements a new space race form.
        /// 
        /// Pre: null
        /// Post: Form implemented for the GUI
        /// </summary>
        public SpaceRaceForm()
        {
            // Setting up the GUI functionality
            InitializeComponent();
            Board.SetUpBoard();
            ResizeGUIGameBoard();
            SetUpGUIGameBoard();

            // Setting up the backend of the program
            // This includes the player objects and attributes
            DetermineNumberOfPlayers();
            SetupPlayersDataGridView();
            SpaceRaceGame.SetUpPlayers();

            // Uses the backend data to talk to the fronted GUI to place the tokens of the players for visualisation
            PrepareToPlay();
        }

        /// <summary>
        /// Handle the Exit button being clicked.
        /// 
        /// Pre:  the Exit button is clicked.
        /// Post: the game is terminated immediately
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // Exits the GUI
            Environment.Exit(0);
        }// exitButton_Click

        /// <summary>
        /// Resizes the entire form, so that the individual squares have their correct size, 
        /// as specified by SquareControl.SQUARE_SIZE.  
        /// This method allows us to set the entire form's size to approximately correct value 
        /// when using Visual Studio's Designer, rather than having to get its size correct to the last pixel.
        /// Pre:  none.
        /// Post: the board has the correct size.
        /// </summary>
        private void ResizeGUIGameBoard()
        {
            const int SQUARE_SIZE = SquareControl.SQUARE_SIZE;
            int currentHeight = tableLayoutPanel.Size.Height;
            int currentWidth = tableLayoutPanel.Size.Width;
            int desiredHeight = SQUARE_SIZE * NUM_OF_ROWS;
            int desiredWidth = SQUARE_SIZE * NUM_OF_COLUMNS;
            int increaseInHeight = desiredHeight - currentHeight;
            int increaseInWidth = desiredWidth - currentWidth;
            this.Size += new Size(increaseInWidth, increaseInHeight);
            tableLayoutPanel.Size = new Size(desiredWidth, desiredHeight);

        }// ResizeGUIGameBoard


        /// <summary>
        /// Creates a SquareControl for each square and adds it to the appropriate square of the tableLayoutPanel.
        /// Pre:  none.
        /// Post: the tableLayoutPanel contains all the SquareControl objects for displaying the board.
        /// </summary>
        private void SetUpGUIGameBoard()
        {
            for (int squareNum = Board.START_SQUARE_NUMBER; squareNum <= Board.FINISH_SQUARE_NUMBER; squareNum++)
            {
                Square square = Board.Squares[squareNum];
                SquareControl squareControl = new SquareControl(square, SpaceRaceGame.Players);
                AddControlToTableLayoutPanel(squareControl, squareNum);
            }//endfor

        }// end SetupGameBoard

        private void AddControlToTableLayoutPanel(Control control, int squareNum)
        {
            int screenRow = 0;
            int screenCol = 0;
            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            tableLayoutPanel.Controls.Add(control, screenCol, screenRow);
        }// end Add Control


        /// <summary>
        /// For a given square number, tells you the corresponding row and column number
        /// on the TableLayoutPanel.
        /// Pre:  none.
        /// Post: returns the row and column numbers, via "out" parameters.
        /// </summary>
        /// <param name="squareNumber">The input square number.</param>
        /// <param name="rowNumber">The output row number.</param>
        /// <param name="columnNumber">The output column number.</param>
        private static void MapSquareNumToScreenRowAndColumn(int squareNum, out int screenRow, out int screenCol)
        {
            // Defining a column checking variable, where it resets every 16
            int colCheck = squareNum % 16;

            // Initilising the columns and rows
            screenCol = 0;
            screenRow = 0;

            // Checking each of the columns
            switch (colCheck)
            {
                case 0:
                case 15:
                    screenCol = 0;
                    break;

                case 1:
                case 14:
                    screenCol = 1;
                    break;

                case 2:
                case 13:
                    screenCol = 2;
                    break;

                case 3:
                case 12:
                    screenCol = 3;
                    break;

                case 4:
                case 11:
                    screenCol = 4;
                    break;

                case 5:
                case 10:
                    screenCol = 5;
                    break;

                case 6:
                case 9:
                    screenCol = 6;
                    break;

                case 7:
                case 8:
                    screenCol = 7;
                    break;

            }

            // Checking each of the rows
            int rowCheck = squareNum / 8;
            switch (rowCheck)
            {
                case 0:
                    screenRow = 6;
                    break;

                case 1:
                    screenRow = 5;
                    break;

                case 2:
                    screenRow = 4;
                    break;

                case 3:
                    screenRow = 3;
                    break;

                case 4:
                    screenRow = 2;
                    break;

                case 5:
                    screenRow = 1;
                    break;

                case 6:
                    screenRow = 0;
                    break;
            }

        }//end MapSquareNumToScreenRowAndColumn


        private void SetupPlayersDataGridView()
        {
            // Stop the playersDataGridView from using all Player columns.
            playerDataGridView.AutoGenerateColumns = false;
            // Tell the playersDataGridView what its real source of data is.
            playerDataGridView.DataSource = SpaceRaceGame.Players;

        }// end SetUpPlayersDataGridView


        /// <summary>
        /// Obtains the current "selected item" from the ComboBox
        ///  and
        ///  sets the NumberOfPlayers in the SpaceRaceGame class.
        ///  Pre: none
        ///  Post: NumberOfPlayers in SpaceRaceGame class has been updated
        /// </summary>
        private void DetermineNumberOfPlayers()
        {
            // Store the SelectedItem property of the ComboBox in a string           
            string NumberOfPlayersString = NumberOfPlayersBox.GetItemText(NumberOfPlayersBox.SelectedItem);

            // Parse string to a number
            int NumberOfPlayersInt = Convert.ToInt32(NumberOfPlayersString);

            // Set the NumberOfPlayers in the SpaceRaceGame class to that number
            SpaceRaceGame.NumberOfPlayers = NumberOfPlayersInt;

        }//end DetermineNumberOfPlayers


        /// <summary>
        /// The players' tokens are placed on the Start square
        /// 
        /// Pre: Players tokens are not drawn on any of the squares
        /// Post: Players tokens are placed on the starting square
        /// </summary>
        private void PrepareToPlay()
        {
            // Removing the players
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            // Intilising the players locations
            SpaceRaceGame.SetUpPlayers();
            // Adding them to the square
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            // Updating the data grib 
            UpdatesPlayersDataGridView();

        }//end PrepareToPlay()


        /// <summary>
        /// Tells you which SquareControl object is associated with a given square number.
        /// Pre:  a valid squareNumber is specified; and
        ///       the tableLayoutPanel is properly constructed.
        /// Post: the SquareControl object associated with the square number is returned.
        /// </summary>
        /// <param name="squareNumber">The square number.</param>
        /// <returns>Returns the SquareControl object associated with the square number.</returns>
        private SquareControl SquareControlAt(int squareNum)
        {
            int screenRow;
            int screenCol;

            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            return (SquareControl)tableLayoutPanel.GetControlFromPosition(screenCol, screenRow);
        }


        /// <summary>
        /// Tells you the current square number of a given player.
        /// Pre:  a valid playerNumber is specified.
        /// Post: the square number of the player is returned.
        /// </summary>
        /// <param name="playerNumber">The player number.</param>
        /// <returns>Returns the square number of the player.</returns>
        private int GetSquareNumberOfPlayer(int playerNumber)
        {
            // Returns the square number of the player
            return SpaceRaceGame.Players[playerNumber].Position;
        }//end GetSquareNumberOfPlayer

        /// <summary>
        /// When the SquareControl objects are updated (when players move to a new square),
        /// the board's TableLayoutPanel is not updated immediately.  
        /// Each time that players move, this method must be called so that the board's TableLayoutPanel 
        /// is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the board's TableLayoutPanel shows the latest information 
        ///       from the collection of SquareControl objects in the TableLayoutPanel.
        /// </summary>
        private void RefreshBoardTablePanelLayout()
        {
            // Uncomment the following line once you've added the tableLayoutPanel to your form.
            tableLayoutPanel.Invalidate(true);
        }

        /// <summary>
        /// When the Player objects are updated (location, etc),
        /// the players DataGridView is not updated immediately.  
        /// Each time that those player objects are updated, this method must be called 
        /// so that the players DataGridView is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the players DataGridView shows the latest information 
        ///       from the collection of Player objects in the SpaceRaceGame.
        /// </summary>
        private void UpdatesPlayersDataGridView()
        {
            SpaceRaceGame.Players.ResetBindings();
        }

        /// <summary>
        /// At several places in the program's code, it is necessary to update the GUI board,
        /// so that player's tokens are removed from their old squares
        /// or added to their new squares. E.g. at the end of a round of play or 
        /// when the Reset button has been clicked.
        /// 
        /// Moving all players from their old to their new squares requires this method to be called twice: 
        /// once with the parameter typeOfGuiUpdate set to RemovePlayer, and once with it set to AddPlayer.
        /// In between those two calls, the players locations must be changed. 
        /// Otherwise, you won't see any change on the screen.
        /// 
        /// Pre:  the Players objects in the SpaceRaceGame have each players current locations
        /// Post: the GUI board is updated to match 
        /// </summary>
        private void UpdatePlayersGuiLocations(TypeOfGuiUpdate typeOfGuiUpdate)
        {
            // Completed this section
            for (int index = 0; index < SpaceRaceGame.NumberOfPlayers; index++)
            {
                // Determining the square number of the player
                int squareNum = GetSquareNumberOfPlayer(index);

                SquareControl squareControl = SquareControlAt(squareNum);

                // Retrieving the SquareControl object
                if (typeOfGuiUpdate == TypeOfGuiUpdate.AddPlayer)
                {
                    squareControl.ContainsPlayers[index] = true;
                }
                if (typeOfGuiUpdate == TypeOfGuiUpdate.RemovePlayer)
                {
                    squareControl.ContainsPlayers[index] = false;
                }
            }
            RefreshBoardTablePanelLayout();//must be the last line in this method. Do not put inside above loop.
        } //end UpdatePlayersGuiLocations

        /// <summary>
        /// Player box selection.
        /// Used to implement changing the number of players for the game.
        /// </summary>
        private void NumberOfPlayersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Whilst the round has not finished
            if (!SpaceRaceGame.roundFinish)
            {
                // Determine the number of players from the box, and then update the data grid and players bindinglist accordingly
                DetermineNumberOfPlayers();
                SpaceRaceGame.SetUpPlayers();
                UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);

            }
            else // whilst the round has finished
            {
                NumberOfPlayersBox.Enabled = false;
                MessageBox.Show("Cannot change number of players! Game is in play.");
            }
        }

        /// <summary>
        /// Implementation of the roll dice button.
        /// This method is called everytime the roll dice button is pressed.
        /// The main functioanlity of this is to play a round for each of the players
        /// </summary>
        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            // If the user has not selected single step
            if (NoRadioButton.Checked)
            {
                // Call the multistep logic function
                MultiStepLogic();

                // Check when the game is over
                if (SpaceRaceGame.GameOverCheck())
                {
                    // Display the end game message
                    DisplayEndGameMessage();
                    // Handling the button properties
                    GameResetButton.Enabled = true;
                    RollDiceButton.Enabled = false;
                }
            }
            // If the user has selected single step
            else if (YesRadioButton.Checked)
            {
                // if the round has finished, we want to reset the boolean to start a new round
                if (SpaceRaceGame.roundFinish)
                {
                    SpaceRaceGame.roundFinish = false;
                }

                // Calling the single step logic method
                SingleStepLogic();
                // Calling the finished round method
                finishedRound();

                // If the game is over 
                if (SpaceRaceGame.GameOverCheck())
                {
                    // Display the game end message
                    DisplayEndGameMessage();
                    // Handling the button properties
                    GameResetButton.Enabled = true;
                    RollDiceButton.Enabled = false;
                }
  
                // If the round is finished, enable the exit button
                if (!SpaceRaceGame.roundFinish)
                {
                    exitButton.Enabled = false;
                }
            }
        }


        /// <summary>
        /// Implementation of the game reset button.
        /// Called when the user presses the game reset button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void GameResetButton_Click(object sender, EventArgs e)
        {
            // Resets the player properties
            PrepareToPlay();

            // Handling the button properties
            YesRadioButton.Checked = false;
            NoRadioButton.Checked = false;
            SingleStep.Enabled = true;

            // Reset the boolean game variables
            SpaceRaceGame.roundFinish = false;
            SpaceRaceGame.gameFinish = false;

            // IF the round has finished 
            if (!SpaceRaceGame.roundFinish)
            {
                // Do not enable the reset button
                GameResetButton.Enabled = false;
            }

            // If the game has finished
            if (!SpaceRaceGame.gameFinish)
            {
                // Do not enable the roll button 
                RollDiceButton.Enabled = false;
            }

        }

        /// <summary>
        /// Implementation of an end game message.
        /// This was put into a method to clean up some code.
        /// The functionality includes a pop up message box which has key information on players at the end of the game.
        /// </summary>
        private void DisplayEndGameMessage()
        {
            
            int counter = 0;

            // Storing a string for the message box
            string finishMessage = "";

            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                if (!SpaceRaceGame.Players[i].AtFinish)
                {
                    counter++;

                }
            }

            // Displaying the players which finished the game
            finishMessage += "The following player(s) finished the game:\n\n";
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                if (SpaceRaceGame.Players[i].AtFinish)
                {
                    finishMessage += "\t" + SpaceRaceGame.Players[i].Name + "\n\n";
                }
            }

            // Displaying the player properties
            finishMessage += "Individual players finished at the location specified:\n\n";
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                finishMessage += "\t" + SpaceRaceGame.Players[i].Name + " with " + SpaceRaceGame.Players[i].RocketFuel + " yottawatt of power at square " + SpaceRaceGame.Players[i].Position + "\n\n";
            }

            // Showing the message box
            MessageBox.Show(finishMessage);
        }


        /// <summary>
        /// Implementation of the yes button for the single step functionality.
        /// If the user selects this, then the game will single step.
        /// </summary>
        private void YesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SingleStep.Enabled = false;
            RollDiceButton.Enabled = true;
        }

        /// <summary>
        /// Implementation of the no button for the single step functionality.
        /// If the user selects this, then the game will not single step.
        /// </summary>
        private void NoRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            SingleStep.Enabled = false;
            RollDiceButton.Enabled = true;
        }//end NoRadioButton_CheckedChanged

        /// <summary>
        /// Determines if the player has finished the round.
        /// Used for the implementation of the single step functionality.
        /// </summary>
        private void finishedRound()
        {
            // If the current player is equal to or greater then the total number of players
            if (currentPlayer >= SpaceRaceGame.NumberOfPlayers)
            {
                // Then the current round is finished
                // We reset all the round parameters
                currentPlayer = 0;
                exitButton.Enabled = true;
                SpaceRaceGame.roundFinish = true;
                // Handling the buttons
                GameResetButton.Enabled = true;
                GameResetButton.Enabled = true;
            }
        }//end finishedRound


        /// <summary>
        /// Implementation of the single step functionality.
        /// This was created as a seperate method to clean up the code.
        /// </summary>
        private void SingleStepLogic()
        {
            // Remove the current players
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);

            // The following code acts as a buffer for the players which have finished the round
            // While the current player does not have power
            while (!SpaceRaceGame.Players[currentPlayer].HasPower)
            {
                // move onto the next player
                currentPlayer++;

                // if the current player is equal to or greater than the number of players
                if (currentPlayer >= SpaceRaceGame.NumberOfPlayers)
                {
                    // Round resets
                    currentPlayer = 0;      
                    exitButton.Enabled = true;
                    GameResetButton.Enabled = true;

                    // if the game has finished
                    if (SpaceRaceGame.gameFinish)
                    {
                        // Display the end game message
                        DisplayEndGameMessage();

                        // Jump to done
                        goto Done;
                    }
                }

            }

            // Play a single round with the current player
            SpaceRaceGame.PlayOneRoundSinglePlayer(SpaceRaceGame.Players[currentPlayer]);

        Done:

            // Add the updated player, and update the datagrid view
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            UpdatesPlayersDataGridView();

            // Iterate to the next player
            currentPlayer++;
        }//end SingleStepLogic


        /// <summary>
        /// Implementation of the functionality without the single step.
        /// This was made into a method to clean up the code.
        /// </summary>
        private void MultiStepLogic()
        {
            // Remove the player, play a round and update the datagrid view and GUI
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            SpaceRaceGame.PlayOneRound();
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            UpdatesPlayersDataGridView();
        }//end MultiStepLogic


        // EMPTY GUI CLASS METHODS
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void playerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Players_Click(object sender, EventArgs e)
        {
        }

        private void NumberOfPlayersLabel_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }// end class
}
