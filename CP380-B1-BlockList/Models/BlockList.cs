using System;
using System.Collections.Generic;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine();
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            var s = block.PreviousHash;
            block.PreviousHash = s;
            Chain.Add(block);
        }

        public bool IsValid()
        {
            int chains = Chain.Count;
            var one = Chain[chains - 1].Hash;
            var two = Chain[chains - 1].PreviousHash;
            bool check = true ;

            for(int i=1;i<Chain.Count;i++)
            {
                if ((Chain[chains - (i+1)].Hash).ToString() == (Chain[chains - i].PreviousHash).ToString().TrimStart('"').TrimEnd('"'))
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            }
            return check;
        }
    }
}
