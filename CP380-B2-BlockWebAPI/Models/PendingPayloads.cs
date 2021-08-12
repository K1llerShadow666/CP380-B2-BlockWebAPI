using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Models
{
    public class PendingPayloads
    {
        public string User { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public int Amount { get; set; }
        public string Item { get; set; }

        public PendingPayloads(Payload payload)
        {
            User = payload.User;
            TransactionType = payload.TransactionType;
            Amount = payload.Amount;
            Item = payload.Item;
        }

        public class BlocksPayload
        {
            public List<PendingPayloads> blockPayload { get; set; }

            public PendingPayloads Add(PendingPayloads pay)
            {
                blockPayload.Add(pay);
                return pay;
            }
        }

    }

}

