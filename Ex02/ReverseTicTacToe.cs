using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Ex02
{
    public partial class ReverseTicTacToe : Form
    {
        public const int k_X = 1;
        public const int k_O = 2;
        private const int k_ButtonSize = 50;
        private const int k_Space = 5;
        private readonly Round r_Round;
        private readonly int r_BoardSize;
        private readonly Board r_Board;

        public ReverseTicTacToe(int i_BoardSize, Player i_Player1, Player i_Player2)
        {
            r_BoardSize = i_BoardSize;
            r_Board = new Board(r_BoardSize);
            r_Round = new Round(i_Player1, i_Player2, r_Board);

            InitializeComponent();
            initializeForm();
        }

        private void initializeForm()
        {
            int startingX = 10;
            int startingY = 10;

            createButtons(startingX, startingY);
            this.ClientSize = new Size(startingX + (k_ButtonSize + k_Space) * r_BoardSize, startingY + (k_ButtonSize + k_Space) * r_BoardSize + Player1.Size.Height + k_Space);
            this.Text = "Reverse Tic Tac Toe";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            createScoreBoard();
        }

        private void createButtons(int i_StartingX, int i_StartingY)
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    Button gameButton = new Button();
                    gameButton.Width = k_ButtonSize;
                    gameButton.Height = k_ButtonSize;
                    gameButton.Left = i_StartingX + (k_ButtonSize + k_Space) * col;
                    gameButton.Top = i_StartingY + (k_ButtonSize + k_Space) * row;
                    gameButton.Name = string.Format("{0},{1}", row, col);
                    gameButton.Click += gameButton_Click;
                    Controls.Add(gameButton);
                }
            }
        }

        private void createScoreBoard()
        {
            updateScoreBoardText();
            Player1.Left = (this.ClientSize.Width / 2) - (Player1.Width + k_Space);
            Player1.Top = this.ClientSize.Height - Player1.Height;
            Controls.Add(Player1);
            Player2.Left = this.ClientSize.Width / 2 + k_Space;
            Player2.Top = this.ClientSize.Height - Player1.Height;
            Controls.Add(Player2);
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            writeOnScreen(((Button)sender), getSign(r_Round.PlayerInPlay.Sign));
            playTurnInLogic(((Button)sender));
        }

        private string getSign(int i_signNumber)
        {
            string sign = "X";
            
            if (i_signNumber == k_O)
            {
                sign = "O";                
            }

            return sign;
        }

        private void playTurnInLogic(Button i_PressedButton)
        {
            if (!r_Round.PlayerInPlay.IsComputer())
            { 
                updateMoveInRound(i_PressedButton);
            }

            r_Round.Turn();
            r_Round.CheckState();
            r_Round.ChangePlayer();
            if (r_Round.State != eState.InProgress)
            {
                endRound(r_Round.State);
            }

            else if (r_Round.PlayerInPlay.IsComputer())
            {
                r_Round.ComputerMove();
                Button buttonPressedByComputer = (Button)this.Controls[string.Format("{0},{1}", r_Round.Move.Row, r_Round.Move.Col)];
                buttonPressedByComputer.PerformClick();
            }
        }

        private void writeOnScreen(Button i_ButtonToWriteOn, string i_Sign)
        {
            i_ButtonToWriteOn.Text = i_Sign;
            i_ButtonToWriteOn.Enabled = false;
        }

        private void updateMoveInRound(Button i_PressedButton)
        {
            string[] rowCol = i_PressedButton.Name.Split(',');

            r_Round.Move = new Move(int.Parse(rowCol[0]), int.Parse(rowCol[1]));
        }

        private void endRound(eState i_RoundState)
        {
            DialogResult result = DialogResult.Yes;

            switch (i_RoundState)
            {
                case eState.Tie:
                    result = MessagesToUser.PrintTie();
                    break;
                case eState.Loss:
                    result = MessagesToUser.PrintWinner(r_Round.PlayerInPlay);
                    r_Round.PlayerInPlay.Score++;
                    break;
            }

            if(result == DialogResult.No)
            {
                Close();
            }
            else
            {
                r_Round.PrepareAnotherRound();
                clearGrid();
                updateScoreBoardText();
            }
        }

        private void clearGrid()
        {
            foreach (Button gameButton in this.Controls.OfType<Button>())
            {
                gameButton.Enabled = true;
                gameButton.Text = string.Empty;
            }
        }

        private void updateScoreBoardText()
        {
            Player1.Text = string.Format("{0}: {1}", r_Round.Player1.PlayerName, r_Round.Player1.Score);
            Player2.Text = string.Format("{0}: {1}", r_Round.Player2.PlayerName, r_Round.Player2.Score);
        }
    }
}
