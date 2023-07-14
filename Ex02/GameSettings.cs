using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex02
{
    public partial class GameSettings : Form
    {
        private string m_Player1Name;
        private string m_Player2Name;
        private int m_BoardSize;
        private int m_NumberOfPlayers = 1;

        public GameSettings()
        {
            InitializeComponent();
            m_Player1Name = string.Empty;
            m_Player2Name = string.Empty;
            m_BoardSize = 4;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public string Player1Name
        {
            get 
            { 
                return m_Player1Name;
            }
        }

        public string Player2Name
        {
            get
            {
                return m_Player2Name;
            }
        }

        public int GameBoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public int NumberOfPlayers
        {
            get
            {
                return m_NumberOfPlayers;
            }
        }

        private void textBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            m_Player1Name = textBoxPlayer1.Text;
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
                m_NumberOfPlayers = 2;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                m_NumberOfPlayers = 1;
            }
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            m_Player2Name = textBoxPlayer2.Text;
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
            m_BoardSize = (int)numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
            m_BoardSize = (int) numericUpDownCols.Value;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
