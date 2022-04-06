using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        /// Method returning grid positions of block
        /// current rotation and offset are factored in
        /// 
        public IEnumerable<Position> TilePositions()
        {
            /// loop over current positions
            foreach (Position p in Tiles[rotationState])
            {
                /// add row offset and column offset
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        /// Rotate the block 90 degrees clockwise
        /// first we increament the current rotation state
        /// going back to zero if in final state
        /// 
       public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }
        /// <summary>
        /// Rotate counter clockwise
        /// </summary>
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
    }
}
 