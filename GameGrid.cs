using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        /// Two dimensional rectangular array
        /// first dimension is row, while second is column
        private readonly int[,] grid;

        /// create properties for number of rows and colums
        public int Rows { get; }

        public int Columns { get; }

        /// indexer to get easier access to the array
        public int this[int row, int col]
        {
            get => grid[row, col];
            set => grid[row, col] = value;
        }

        /// Constructor that takes number of rows and colums as parameters
        
        public GameGrid(int rows, int columns)
        {
            /// Save number of rows and columns
            /// Then initialise the array
            this.Rows = rows;   
            this.Columns = columns;
            this.grid = new int[rows, columns];
        }
        /// Create convinience methods
        
        ///check if given row and column is inside the grid
        ///
        public bool IsInside(int row, int col)
        {
            return row >= 0 && row < Rows && col >= 0 && col < Columns;  
        }

        /// Check if cell is empty or not
        /// 
        public bool IsEmpty(int row, int col)
        {
            /// first check if it is inside the gamespace
            /// then check if grid is empty
            /// both need to be true
            return IsInside(row, col) && grid[row, col] == 0;
        }

        /// Check if row is full
        /// 
        public bool IsRowFull(int row)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (grid[row, col] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// Check if row is empty
        /// 
        public bool IsRowEmpty(int row)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (grid[row,col] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
