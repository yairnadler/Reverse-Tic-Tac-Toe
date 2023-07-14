namespace Ex02
{
    public class GameInitializer
    {
        public const int k_X = 1;
        public const int k_O = 2;
        private readonly GameSettings r_GameSettings;
        private ReverseTicTacToe m_ReverseTicTacToe;

        public GameInitializer() 
        {
            r_GameSettings = new GameSettings();
        }
        public void Play()
        {
            r_GameSettings.ShowDialog();
            initializeGame();
            m_ReverseTicTacToe.ShowDialog();
        }
        private void initializeGame()
        {
            int boardSize;
            int numberOfPlayers = 0;
            Player player1, player2;

            boardSize = r_GameSettings.GameBoardSize;
            Board board = new Board(boardSize);
            numberOfPlayers = r_GameSettings.NumberOfPlayers;
            player1 = new Player(r_GameSettings.Player1Name, k_X);
            if (numberOfPlayers > 1)
            { 
                player2 = new Player(r_GameSettings.Player2Name, k_O);
            }
            else
            {
                player2 = new Player();
            }

            m_ReverseTicTacToe = new ReverseTicTacToe(boardSize, player1, player2);
        }
    }
}
