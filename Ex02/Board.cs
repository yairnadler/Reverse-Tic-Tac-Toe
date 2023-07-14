using System.Dynamic;

namespace Ex02
{
    public class Board
    {
        private int m_Capacity;
        private int[,] m_Grid;
        private readonly int r_GridRowColLength;
        private const int k_FreeSlot = 0;
        private const int k_MainDiagonal = 1;
        private const int k_SecondaryDiagonal = 2;
        public Board(int i_Size) 
        {
            m_Grid = new int[i_Size, i_Size];
            m_Capacity = i_Size * i_Size;
            r_GridRowColLength = i_Size;
        }
        public int Capacity 
        {
            get 
            { 
                return m_Capacity; 
            }
        }
        public int[,] Grid
        {
            get
            {
                return m_Grid;
            }
        }
        public int GridRowColLength
        {
            get
            {
                return r_GridRowColLength;
            }
        }
        public void ClearBoard()
        {
            m_Grid = new int[r_GridRowColLength, r_GridRowColLength];
            m_Capacity = r_GridRowColLength * r_GridRowColLength;
        }
        public void Write(Move i_Slot, int i_PlayerSign)
        {
            m_Grid[i_Slot.Row, i_Slot.Col] = i_PlayerSign;
            m_Capacity--;
        }
        public bool IsFull()
        {
            bool isFull = false;
            
            if (m_Capacity == 0)
            {
                isFull = true;
            }
            
            return isFull;
        }
        private bool isRowHomogeneous(Move i_Slot, int i_PlayerSign) 
        {
            bool isRowHomogeneous = true;
            
            for(int col = 0; col < r_GridRowColLength; col++)
            {
                if (m_Grid[i_Slot.Row, col] != i_PlayerSign) 
                { 
                    isRowHomogeneous = false;
                    break;
                }
            }
            
            return isRowHomogeneous;
        }
        private bool isColHomogeneous(Move i_Slot, int i_PlayerSign)
        {
            bool isColHomogeneous = true;
            
            for (int row = 0; row < r_GridRowColLength; row++)
            {
                if (m_Grid[row, i_Slot.Col] != i_PlayerSign)
                {
                    isColHomogeneous = false;
                    break;
                }
            }
            
            return isColHomogeneous;
        }
        private bool isDiagonalHomogeneous(int i_PlayerSign, int i_Diagonal)
        {
            bool isDiagonalHomogeneous = true;
            
            if(i_Diagonal == k_MainDiagonal)
            {
                for(int i = 0; i < r_GridRowColLength; i++)
                {
                    if (m_Grid[i, i] != i_PlayerSign)
                    {
                        isDiagonalHomogeneous = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < r_GridRowColLength; i++)
                {
                    if (m_Grid[r_GridRowColLength - i - 1, i] != i_PlayerSign)
                    {
                        isDiagonalHomogeneous = false;
                        break;
                    }
                }
            }
            
            return isDiagonalHomogeneous;
        }
        private int diagonalDirection(Move i_Slot)
        {
            int diagonalDirection = 0;
            
            if(i_Slot.Col == i_Slot.Row)
            {
                diagonalDirection += k_MainDiagonal;
            }
            
            if(i_Slot.Col == r_GridRowColLength - i_Slot.Row - 1)
            {
                diagonalDirection += k_SecondaryDiagonal;
            }
            
            return diagonalDirection;
        }
        public bool ContainsLoss(Move i_Slot, int i_PlayerSign)
        {
            bool containsLoss = isColHomogeneous(i_Slot, i_PlayerSign) || isRowHomogeneous(i_Slot, i_PlayerSign);

            switch (diagonalDirection(i_Slot))
            {
                case k_MainDiagonal:
                    containsLoss = containsLoss || isDiagonalHomogeneous(i_PlayerSign, k_MainDiagonal);
                    break;
                case k_SecondaryDiagonal:
                    containsLoss = containsLoss || isDiagonalHomogeneous(i_PlayerSign, k_SecondaryDiagonal);
                    break;
                case (k_MainDiagonal + k_SecondaryDiagonal):
                    containsLoss = containsLoss || isDiagonalHomogeneous(i_PlayerSign, k_MainDiagonal) || isDiagonalHomogeneous(i_PlayerSign, k_SecondaryDiagonal);
                    break;
            }
            
            return containsLoss;
        }
        public Move GetRandomFreeSlot(int i_RandomSlot)
        {
            int freeSlotCounter = 0;
            Move freeSlot = null;
            
            for (int i = 0;i < r_GridRowColLength; i++)
            {
                for (int j = 0;j < r_GridRowColLength; j++)
                {
                    if (!IsSlotTaken(i, j))
                    {
                        freeSlotCounter++;
                        if (freeSlotCounter == i_RandomSlot)
                        {
                            freeSlot = new Move(i, j);
                            break;
                        }
                    }

                }
            }
            
            return freeSlot;
        } 
        public bool IsSlotTaken(int i_row, int i_col)
        {
            bool isSlotTaken = false;
            
            if(m_Grid[i_row, i_col] != k_FreeSlot)
            {
                isSlotTaken = true;
            }
            
            return isSlotTaken;
        }
    }
}
