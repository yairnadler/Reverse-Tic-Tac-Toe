namespace Ex02
{
    public class Move
    {
        private int m_Row;
        private int m_Col;
        private bool m_QuitRound = false;
        private bool m_isValid = false;
        public Move(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }
        public void QuitRound()
        {
            m_QuitRound = true;
        }
        public int Row 
        { 
            get 
            { 
                return m_Row; 
            }
            set
            {
                m_Row= value;
            }
        }
        public int Col
        {
            get
            {
                return m_Col;
            }
            set 
            {
                m_Col= value; 
            }
        }
        public bool Quit
        {
            get
            {
                return m_QuitRound;
            }
        }
        public bool IsValid
        {
            get
            {
                return m_isValid;
            }
            set 
            { 
                m_isValid = value; 
            }
        }
    }
}
