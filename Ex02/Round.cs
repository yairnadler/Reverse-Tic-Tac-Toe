using System;
using static Ex02.MessagesToUser;

namespace Ex02
{
    public enum eState
    {
        InProgress,
        Tie,
        Loss,
        Quit,
    }
    public class Round
    {
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly Board r_Board;
        private Player m_PlayerInPlay;
        private Move m_Move;
        private eState m_State = eState.InProgress;
        public Round(Player i_Player1, Player i_Player2, Board i_Board) 
        { 
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
            r_Board = i_Board;
            m_PlayerInPlay = r_Player1;
        }
        public Board Board 
        { 
            get 
            { 
                return r_Board; 
            } 
        }
        public eState State 
        { 
            get 
            { 
                return m_State; 
            } 
        }
        public Move Move
        {
            get
            {
                return m_Move;
            }
            set
            {
                m_Move = value;
            }
        }
        public Player PlayerInPlay
        {
            get
            {
                return m_PlayerInPlay;
            }
        }
        public Player Player1
        {
            get
            {
                return r_Player1;
            }
        }
        public Player Player2
        {
            get
            {
                return r_Player2;
            }
        }
        private bool wantsToQuit()
        {
            bool wantsToQuit = false;
            
            if (m_Move.Quit)
            {
                m_State = eState.Quit;
                wantsToQuit = true;
            }
            
            return wantsToQuit;
        }
        public void Turn()
        {
            r_Board.Write(m_Move, m_PlayerInPlay.Sign);
        }
        public void ComputerMove()
        {
            Random randomSlot = new Random();
            int slot = randomSlot.Next(r_Board.Capacity) + 1;
            m_Move = r_Board.GetRandomFreeSlot(slot);   
        }
        public void CheckState()
        {
            if (r_Board.ContainsLoss(m_Move, m_PlayerInPlay.Sign))
            {
                m_State = eState.Loss;
            }
            else if (r_Board.IsFull())
            {
                m_State = eState.Tie;
            }
        }
        public void ChangePlayer()
        {
            if (m_PlayerInPlay.Sign == r_Player1.Sign)
            {
                m_PlayerInPlay = r_Player2;
            }
            else
            {
                m_PlayerInPlay = r_Player1;
            }
        }
        public bool HasValidMove()
        {
            return wantsToQuit() || !r_Board.IsSlotTaken(m_Move.Row, m_Move.Col);
        }
        public void EndRound()
        {
            switch (m_State)
            {
                case eState.Tie:
                    PrintTie();
                    break;
                case eState.Loss:
                    PrintWinner(m_PlayerInPlay);
                    m_PlayerInPlay.Score++;
                    break; 
            }
        }
        public void PrepareAnotherRound()
        {
            r_Board.ClearBoard();
            m_State= eState.InProgress;
            m_PlayerInPlay = r_Player1;
        }
    } 
}
