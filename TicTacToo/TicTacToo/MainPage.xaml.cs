using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace TicTacToo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Set up a list of buttons to react to
        /// </summary>
        private Button[] _buttons = new Button[9];

        /// <summary>
        /// Create an instance of the game engine
        /// </summary>
        private GameEngine _game = new GameEngine();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TicTacToo.MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            _buttons[0] = button1;
            _buttons[1] = button2;
            _buttons[2] = button3;
            _buttons[3] = button4;
            _buttons[4] = button5;
            _buttons[5] = button6;
            _buttons[6] = button7;
            _buttons[7] = button8;
            _buttons[8] = button9;


        }

        /// <summary>
        /// Handle the click event on a button
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void button_Clicked(object sender, EventArgs e)
        {
            _game.SetButton((Button)sender);

            // check to see if there is a winner
            if (_game.CheckWinner(_buttons))
            {
                // if so, show the game over stack
                gameOverStackLayout.IsVisible = true;
            }
        }

        /// <summary>
        /// Play again 
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void playagain_Clicked(Object sender, EventArgs e)
        {
            // reset the game with the array of buttons
            _game.ResetGame(_buttons);
            // hide the game over stack
            gameOverStackLayout.IsVisible = false;
        }
    }
}
