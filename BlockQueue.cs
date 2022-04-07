using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Picks the next block in the game. The next block in the queue/line
    /// </summary>
    public class BlockQueue
    {
        ///Array of the 7 block classes
        ///
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new SBlock(),
            new ZBlock(),
            new OBlock(),
            new TBlock()
        };

        private readonly Random random = new Random();

        /// <summary>
        /// this will be used on the UI to preview what is next
        /// </summary>
        public Block NextBlock { get; private set; }

        /// Initialise next block with random block
        /// 
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        /// Method to return a random block
        /// 
        public Block RandomBlock() 
        { 
            return blocks[random.Next(blocks.Length)];
        }

        /// Return next block and update NextBlock
        /// 
        public Block GetAndUpdate()
        {
            Block block = NextBlock;


            /// We do not want the same block twice in a row,
            /// so we keep picking until we find a new block
            /// a different block
            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }

    }
}
