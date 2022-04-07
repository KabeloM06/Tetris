using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class JBlock : Block
    {
        /// Tile positions for the four rotation states
        /// 
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[]
            {
                ///Start position/hook facing up on left
                new(0,0), new(1,0), new(1,1), new(1,2)
            },
            new Position[]
            {
                ///Upright/ hook up facing right
                new(0,1), new(0,2), new(1,1), new(2,1)
            },
            new Position[]
            {
                ///flat again/ Hook pointing down on right
                new(1,0), new(1,1), new(1,2), new(2,2)
            },
            new Position[]
            {
                ///hook at bottom facing left
                new(0,1), new(1,1), new(2,0), new(2,1)
            }
        };

        public override int Id => 2;

        /// <summary>
        /// Make Block spawn in middle of to row
        /// </summary>
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
