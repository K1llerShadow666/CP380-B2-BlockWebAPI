using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Models
{
    public class BlockSummary
    {
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
     

        public BlockSummary(Block block)
        {
            TimeStamp = block.TimeStamp;
            PreviousHash = block.PreviousHash;
            Hash = block.Hash;
        }

        public class Blocks
        {
            public List<BlockSummary> block { get; set; }
        }

        public class BlocksPayload
        {
            public List<Block> blockPayload { get; set; }
        }
    }
}
