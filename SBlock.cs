using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class SBlock : Block
    {
        /// Tile positions for the four rotation states
        /// 
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[]
            {
                ///Start position/flat with top of chair facing right
                new(0,1), new(0,2), new(1,0), new(1,1)
            },
            new Position[]
            {
                ///Upright/ chair facing right
                new(0,1), new(1,1), new(1,2), new(2,2)
            },
            new Position[]
            {
                ///flat again/ top of chair facing right
                new(1,1), new(1,2), new(2,0), new(2,1)
            },
            new Position[]
            {
                ///upright/ chair facing right
                new(0,0), new(1,0), new(1,1), new(2,1)
            }
        };

        public override int Id => 5;

        /// <summary>
        /// Make Block spawn in middle of to row
        /// </summary>
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
