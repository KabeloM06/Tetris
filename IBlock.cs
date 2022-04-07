using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class IBlock : Block
    {
        /// Tile positions for the four rotation states
        /// 
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[]
            {
                ///Start position/flat
                new(1,0), new(1,1), new(1,2), new(1,3)
            },
            new Position[]
            {
                ///Upright
                new(0,2), new(1,2), new(2,2), new(3,2)
            },
            new Position[]
            {
                ///flat again
                new(2,0), new(2,1), new(2,2), new(2,3)
            },
            new Position[]
            {
                ///Start position/flat
                new(0,1), new(1,1), new(2,1), new(3,1)
            }
        };

        public override int Id => 1;

        /// <summary>
        /// Make Block spawn in middle of to row
        /// </summary>
        protected override Position StartOffset => new Position(-1, 3);
        protected override Position[][] Tiles => tiles;
    }
}
