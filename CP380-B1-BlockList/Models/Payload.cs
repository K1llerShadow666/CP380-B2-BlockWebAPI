
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        // declaring fields to be used elsewhere
        public string User;
        public string Item;
        public int Amount;
        public TransactionTypes ttInfo;
    }
}
