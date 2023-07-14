using System.Windows.Forms;

namespace Ex02
{
    public static class MessagesToUser
    {
        public static DialogResult PrintTie()
        {
            string message = string.Format(
@"Tie!
Would you like to play another round?");
            const string caption = "A Tie!";
            
            return MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

        }

        public static DialogResult PrintWinner(Player i_Player)
        {
            string message = string.Format(
@"{0} Won!
Would you like to play another round?", i_Player.PlayerName);
            const string caption = "A Win!";

            return MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
        }
    }
}


