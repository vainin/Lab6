namespace Lab6Starter;
/**
 * 
 * Name: Benjamin Wastart and Alex Rodriguez
 * Date: Nov 7, 2022
 * Description: A single page application of TicTacToe.
 * Bugs: Doesn't like playing in windows machine.
 * Reflection: This was an easier lab other than having to keep making new forks.
 * 
 */

using Lab6Starter;
using System.Collections;


/// <summary>
/// The MainPage, this is a 1-screen app
/// </summary>
public partial class MainPage : ContentPage
{
    TicTacToeGame ticTacToe; // model class
    Button[,] grid;          // stores the buttons
    ArrayList myColors;     //holds color options


    /// <summary>
    /// initializes the component
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
        ticTacToe = new TicTacToeGame();
        grid = new Button[TicTacToeGame.GRID_SIZE, TicTacToeGame.GRID_SIZE] { { Tile00, Tile01, Tile02 }, { Tile10, Tile11, Tile12 }, { Tile20, Tile21, Tile22 } };
        initColors();
    }

    /// <summary>
    /// Handles button clicks - changes the button to an X or O (depending on whose turn it is)
    /// Checks to see if there is a victory - if so, invoke 
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleButtonClick(object sender, EventArgs e)
    {
        Player victor;
        Player currentPlayer = ticTacToe.CurrentPlayer;

        Button button = (Button)sender;
        int row;
        int col;

        FindTappedButtonRowCol(button, out row, out col);
        if (button.Text.ToString() != "")
        { // if the button has an X or O, bail
            DisplayAlert("Illegal move", "Fill this in with something more meaningful", "OK");
            return;
        }
        button.Text = currentPlayer.ToString();
        Boolean gameOver = ticTacToe.ProcessTurn(row, col, out victor);

        if (gameOver)
        {
            CelebrateVictory(victor);

        }
    }

    /// <summary>
    /// Returns the row and col of the clicked row
    /// There used to be an easier way to do this ...
    /// </summary>
    /// <param name="button"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void FindTappedButtonRowCol(Button button, out int row, out int col)
    {
        row = -1;
        col = -1;

        for (int r = 0; r < TicTacToeGame.GRID_SIZE; r++)
        {
            for (int c = 0; c < TicTacToeGame.GRID_SIZE; c++)
            {
                if(button == grid[r, c])
                {
                    row = r;
                    col = c;
                    return;
                }
            }
        }
        
    }


    /// <summary>
    /// Celebrates victory, displaying a message box and resetting the game
    /// </summary>
    private void CelebrateVictory(Player victor)
    {
        //MessageBox.Show(Application.Current.MainPage, String.Format("Congratulations, {0}, you're the big winner today", victor.ToString()));
        DisplayAlert("Sweeto Buritto", String.Format("Congratulations, {0}, you're the big winner today", victor.ToString()), "Cool");
        XScoreLBL.Text = String.Format("X's Score: {0}", ticTacToe.XScore);
        OScoreLBL.Text = String.Format("O's Score: {0}", ticTacToe.OScore);

        ResetGame();
    }

    /// <summary>
    /// Resets the grid buttons so their content is all ""
    /// </summary>
    private void ResetGame()//object sender, EventArgs e)
    {
        ticTacToe.ResetGame();
        RandomColor();
        Tile00.Text = "";
        Tile01.Text = "";
        Tile02.Text = "";
        Tile10.Text = "";
        Tile11.Text = "";
        Tile12.Text = "";
        Tile20.Text = "";
        Tile21.Text = "";
        Tile22.Text = "";

    }

    private void HandleResetClick(object sender, EventArgs e)
    {
        ResetGame();
        
    }

    private void RandomColor()
    {
        Random rnd = new Random();
        int pattern = rnd.Next(0, 10);
        
        if (pattern > 8)
        {
            int color = rnd.Next(0, myColors.Count);  // creates a number between 0 and count

            Tile00.BackgroundColor = (Color)myColors[color];
            Tile01.BackgroundColor = (Color)myColors[color];
            Tile02.BackgroundColor = (Color)myColors[color];
            Tile10.BackgroundColor = (Color)myColors[color];
            Tile11.BackgroundColor = (Color)myColors[color];
            Tile12.BackgroundColor = (Color)myColors[color];
            Tile20.BackgroundColor = (Color)myColors[color];
            Tile21.BackgroundColor = (Color)myColors[color];
            Tile22.BackgroundColor = (Color)myColors[color];
        }
        else if(pattern > 6)
        {
            int color = rnd.Next(0, myColors.Count);  // creates a number between 0 and count
            int color2 = rnd.Next(0, myColors.Count);
            Tile00.BackgroundColor = (Color)myColors[color2];
            Tile01.BackgroundColor = (Color)myColors[color2];
            Tile02.BackgroundColor = (Color)myColors[color2];
            Tile10.BackgroundColor = (Color)myColors[color];
            Tile11.BackgroundColor = (Color)myColors[color];
            Tile12.BackgroundColor = (Color)myColors[color];
            Tile20.BackgroundColor = (Color)myColors[color2];
            Tile21.BackgroundColor = (Color)myColors[color2];
            Tile22.BackgroundColor = (Color)myColors[color2];
        }
        else if (pattern > 3)
        {
            int color = rnd.Next(0, myColors.Count);  // creates a number between 0 and count
            int color2 = rnd.Next(0, myColors.Count);
            Tile00.BackgroundColor = (Color)myColors[color2];
            Tile01.BackgroundColor = (Color)myColors[color];
            Tile02.BackgroundColor = (Color)myColors[color2];
            Tile10.BackgroundColor = (Color)myColors[color];
            Tile11.BackgroundColor = (Color)myColors[color];
            Tile12.BackgroundColor = (Color)myColors[color];
            Tile20.BackgroundColor = (Color)myColors[color2];
            Tile21.BackgroundColor = (Color)myColors[color];
            Tile22.BackgroundColor = (Color)myColors[color2];
        }
        else
        {
            int color = rnd.Next(0, myColors.Count);  // creates a number between 0 and count
            int color2 = rnd.Next(0, myColors.Count);
            Tile00.BackgroundColor = (Color)myColors[color];
            Tile01.BackgroundColor = (Color)myColors[color2];
            Tile02.BackgroundColor = (Color)myColors[color];
            Tile10.BackgroundColor = (Color)myColors[color2];
            Tile11.BackgroundColor = (Color)myColors[color];
            Tile12.BackgroundColor = (Color)myColors[color2];
            Tile20.BackgroundColor = (Color)myColors[color];
            Tile21.BackgroundColor = (Color)myColors[color2];
            Tile22.BackgroundColor = (Color)myColors[color];
        }
        
    }

    //Make a list of usable colors
    private void initColors()
    {
        myColors = new ArrayList();
        myColors.Add(Colors.Red);
        myColors.Add(Colors.Green);
        myColors.Add(Colors.SkyBlue);
        myColors.Add(Colors.Aqua);
        myColors.Add(Colors.LightCoral);
        myColors.Add(Colors.RosyBrown);
        myColors.Add(Colors.Violet);
        myColors.Add(Colors.LightGray);
        myColors.Add(Colors.Gold);
    }

}



