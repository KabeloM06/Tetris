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

    }
}
