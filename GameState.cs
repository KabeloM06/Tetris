using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);    
                    }
                }
            }
        }

        
        public GameGrid GameGrid { get; }

        public BlockQueue BlockQueue { get; }

        public bool GameOver { get; private set; }

        public int Score { get; private set; }


        /// <summary>
        /// initialise gamegride with 22 rows and 10 columns
        /// start the block queue and current game block
        /// </summary>
 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GameState()
 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        /// Check if current block is in a legal posotion or not
        /// 
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                /// If blocks are over other tiles
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        /// Rotate block clockWise
        /// But only if it is possible to do in current location
        /// otherwise rotate counter clock wise
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        /// Rotate block counter clockWise
        /// But only if it is possible to do in current location
        /// otherwise rotate clock wise
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        /// Methods to move block left and right
        /// if it moves into an illegal position, then we move it back
        /// 
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        /// Called when current block cannot be moved down
        /// 
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        /// Determine how many block left for block to drop
        /// Part of creating the drop function with one key
        /// 
        private int TileDropDistance(Position p)
        {
            int drop = 0;

            while (GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;

            foreach (Position p in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
