using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TBlock : Block
    {
        /// Tile positions for the four rotation states
        /// 
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[]
            {
                ///Start position/head facing up
                new(0,1), new(1,0), new(1,1), new(1,2)
            },
            new Position[]
            {
                ///head facing right
                new(0,1), new(1,1), new(1,2), new(2,1)
            },
            new Position[]
            {
                ///head facing down
                new(1,0), new(1,1), new(1,2), new(2,1)
            },
            new Position[]
            {
                ///head facing left
                new(0,1), new(1,0), new(1,1), new(2,1)
            }
        };

        public override int Id => 6;

        /// <summary>
        /// Make Block spawn in middle of to row
        /// </summary>
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
