using Xamarin.Forms;

namespace TicTacToo
{
    /// <summary>
    /// This is the game engine of Tic Tac Too
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// Which players turn is it
        /// </summary>
        private int _playerTurn = 1;

        /// <summary>
        /// Winning combinations
        /// </summary>
        private readonly int[,] _winningCombinations = new int[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}

        };

        /// <summary>
        /// Counter variable
        /// </summary>
        private int _counter;

        /// <summary>
        /// Check to see if a winner exists
        /// </summary>
        /// <returns><c>true</c>, if winner was checked, <c>false</c> otherwise.</returns>
        /// <param name="buttons">Buttons.</param>
        public bool CheckWinner(Button[] buttons)
        {
            bool gameOver = false;
            for (_counter = 0; _counter < 8; _counter++)
            {
                int a = _winningCombinations[_counter, 0], b = _winningCombinations[_counter, 1], c = _winningCombinations[_counter, 2];
                Button b1 = buttons[a], b2 = buttons[b], b3 = buttons[c];


                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                    continue;

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    b1.BackgroundColor = b2.BackgroundColor = b3.BackgroundColor = Color.Aqua;
                    gameOver = true;
                    break;
                }
            }

            bool isTie = true;
            if (!gameOver)

            {
                foreach (Button b in buttons)
                {
                    if (b.Text == "")
                    {
                        isTie = false;
                        break;
                    }
                }
                if (isTie)
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }

        /// <summary>
        /// Change teh button
        /// </summary>
        /// <param name="b">The blue component.</param>
        public void SetButton(Button b)
        {
            if (b.Text == "")
            {
                // depending on the current player, set the X or O
                b.Text = _playerTurn == 1 ? "X" : "O";

                // next players turn
                _playerTurn = _playerTurn == 1 ? 2 : 1;
            }
        }

        /// <summary>
        /// Resets the game.
        /// </summary>
        /// <param name="buttons">Buttons.</param>
        public void ResetGame(Button[] buttons)
        {
            _playerTurn = 1;
            foreach (Button b in buttons)
            {
                b.Text = "";
                b.BackgroundColor = Color.Silver;
            }
        }
    }
}
