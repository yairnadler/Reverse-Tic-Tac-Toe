namespace Ex02
{
    public enum ePlayerType
    {
        Computer,
        Human,
    }
    public class Player
    {
        private readonly ePlayerType r_PlayerType;
        private readonly string r_PlayerName;
        private readonly int r_Sign;
        private int m_Score = 0;
        private const int k_ComputerSign = 2;
        public Player(string i_playerName, int i_Sign)
        {
            r_PlayerName = i_playerName;
            r_PlayerType = ePlayerType.Human;
            r_Sign = i_Sign;
        }
        public Player()
        {
            r_PlayerName = "Computer";
            r_PlayerType = ePlayerType.Computer;
            r_Sign = k_ComputerSign;
        }
        public ePlayerType PlayerType
        {
            get 
            { 
                return r_PlayerType;
            }
        }
        public string PlayerName
        {
            get
            {
                return r_PlayerName;
            }
        }
        public int Sign
        {
            get 
            {
                return r_Sign; 
            }
        }
        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }
        public bool IsComputer()
        {
            bool isComputer = false;
            
            if(r_PlayerType == ePlayerType.Computer)
            {
                isComputer = true;
            }
            
            return isComputer;
        }
    }
}
