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
        int click = 0;

        // When we update what's on the screen, we show the movement of a player 
        // by removing them from their old square and adding them to their new square.
        // This enum makes it clear that we need to do both.
        enum TypeOfGuiUpdate { AddPlayer, RemovePlayer };


        public SpaceRaceForm()
        {
            InitializeComponent();

            Board.SetUpBoard();
            ResizeGUIGameBoard();
            SetUpGUIGameBoard();
            DetermineNumberOfPlayers();
            SetupPlayersDataGridView();
            SpaceRaceGame.SetUpPlayers();
            PrepareToPlay();
            ExitButtonCondition();



            // test();

        }

        private void test()
        {
            // Grabbing the users input and converting to an integer.
            string numberOfPlayersStr = NumberOfPlayersBox.SelectedText;
            int numberOfPlayersInt;

            numberOfPlayersInt = Convert.ToInt32(numberOfPlayersStr);

            Console.WriteLine("{0}", numberOfPlayersInt);

        }


        /// <summary>
        /// Handle the Exit button being clicked.
        /// Pre:  the Exit button is clicked.
        /// Post: the game is terminated immediately
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // The exit button is enabled at the start of the game
            // The exit button is disabled during any round
            // The exit button is enabled after each round
            if (SpaceRaceGame.resetRound)
            {
                exitButton.Enabled = true;
            }

            Environment.Exit(0);
        }


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
            int colCheck = squareNum % 16;

            screenCol = 0;
            screenRow = 0;

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
        /// </summary>
        private void PrepareToPlay()
        {
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            SpaceRaceGame.resetGame();
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
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

        // update one player location on GUI at a time
        private void UpdateOldPlayerGuiLocation(int playerNumber, int squareNumber, TypeOfGuiUpdate typeOfGuiUpdate)
        {
            SquareControl squareControl = SquareControlAt(squareNumber);

            // Retrieving the SquareControl object
            if (typeOfGuiUpdate == TypeOfGuiUpdate.AddPlayer)
            {
                squareControl.ContainsPlayers[playerNumber] = true;
            }
            if (typeOfGuiUpdate == TypeOfGuiUpdate.RemovePlayer)
            {
                squareControl.ContainsPlayers[playerNumber] = false;
            }

            RefreshBoardTablePanelLayout();//must be the last line in this method. Do not put inside above loop.
        }


        private void UpdateSinglePlayerGuiLocations(int PlayerNumber, TypeOfGuiUpdate typeOfGuiUpdate)
        {
            // Completed this section
            
            // Determining the square number of the player
            int squareNum = GetSquareNumberOfPlayer(PlayerNumber);

            SquareControl squareControl = SquareControlAt(squareNum);

            // Retrieving the SquareControl object
            if (typeOfGuiUpdate == TypeOfGuiUpdate.AddPlayer)
            {
                squareControl.ContainsPlayers[PlayerNumber] = true;
            }
            if (typeOfGuiUpdate == TypeOfGuiUpdate.RemovePlayer)
            {
                squareControl.ContainsPlayers[PlayerNumber] = false;
            }

            RefreshBoardTablePanelLayout();//must be the last line in this method. Do not put inside above loop.
        } //end UpdateSinglePlayerGuiLocations

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


        private void NumberOfPlayersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SpaceRaceGame.resetRound)
            {
                DetermineNumberOfPlayers();
                SpaceRaceGame.SetUpPlayers();
                UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);

            }
            else
            {
                NumberOfPlayersBox.Enabled = false;
                MessageBox.Show("Cannot change number of players! Game is in play.");
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            if (NoRadioButton.Checked)
            {
                MultiStepLogic();
            }

            else if (YesRadioButton.Checked)
            {
                
                SingleStepLogic();
                click++;
            }

            if (SpaceRaceGame.resetRound)
            {
                GameResetButton.Enabled = true;
            }

            if (SpaceRaceGame.gameFinish)
            {

                // Displaying the end game message
                DisplayEndGameMessage();

                RollDiceButton.Enabled = false;
            }
        }

        private int StoreLocationOfPlayers(int playerNumber)
        {    
            return SpaceRaceGame.Players[playerNumber].Position;
        }


        private void GameResetButton_Click(object sender, EventArgs e)
        {

            PrepareToPlay();


            YesRadioButton.Checked = false;
            NoRadioButton.Checked = false;
            SingleStep.Enabled = true;


            if (!SpaceRaceGame.resetRound)
            {
                GameResetButton.Enabled = false;
            }


            SpaceRaceGame.resetRound = false;
            SpaceRaceGame.gameFinish = false;

            if (!SpaceRaceGame.gameFinish)
            {
                RollDiceButton.Enabled = false;
            }

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DisplayEndGameMessage()
        {
            // 
            int counter = 0;
            string finishMessage = "";

            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                if (!SpaceRaceGame.Players[i].AtFinish)
                {
                    counter++;

                }
            }

            finishMessage += "The following player(s) finished the game:\n\n";
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                if (SpaceRaceGame.Players[i].AtFinish)
                {
                    finishMessage += "\t" + SpaceRaceGame.Players[i].Name + "\n\n";
                }
            }

            finishMessage += "Individual players finished at the location specified:\n\n";

            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                finishMessage += "\t" + SpaceRaceGame.Players[i].Name + " with " + SpaceRaceGame.Players[i].RocketFuel + " yottawatt of power at square " + SpaceRaceGame.Players[i].Position + "\n\n";
            }

            MessageBox.Show(finishMessage);
        }


        /// <summary>
        /// This method implements the functionality to enable and disable the exit button depending on the conditions as per the task sheet
        /// </summary>
        private void ExitButtonCondition()
        {
            if (SpaceRaceGame.resetRound)
            {
                exitButton.Enabled = false;
            }
        }



        private void YesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SingleStep.Enabled = false;
            RollDiceButton.Enabled = true;
            

        }

        private void NoRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            SingleStep.Enabled = false;
            RollDiceButton.Enabled = true;
        }

        private void SingleStepLogic()
        {
            int[] oldPosition = new int[SpaceRaceGame.NumberOfPlayers];
            if (click % SpaceRaceGame.NumberOfPlayers == 0)
            {
                SpaceRaceGame.PlayOneRound();
                
                for (int index = 0; index < SpaceRaceGame.NumberOfPlayers; index++)
                {
                    oldPosition[index] = StoreLocationOfPlayers(index);
                }
            }

            UpdateOldPlayerGuiLocation(click % SpaceRaceGame.NumberOfPlayers, oldPosition[click], TypeOfGuiUpdate.RemovePlayer);
            
            UpdateSinglePlayerGuiLocations(click % SpaceRaceGame.NumberOfPlayers, TypeOfGuiUpdate.RemovePlayer);
            UpdateSinglePlayerGuiLocations(click % SpaceRaceGame.NumberOfPlayers, TypeOfGuiUpdate.AddPlayer);

            // update individually
            UpdatesPlayersDataGridView();
        }

        private void MultiStepLogic()
        {
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            SpaceRaceGame.PlayOneRound();
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            UpdatesPlayersDataGridView();
        }
        
    }// end class
}
