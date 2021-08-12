using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CP380_B1_BlockList.Models
{
    public class Block
    {
        public int Nonce { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public List<Payload> Data { get; set; }

        public Block(DateTime timeStamp, string previousHash, List<Payload> data)
        {
            Nonce = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Data = data;
            Hash = CalculateHash();
        }

        
        public string CalculateHash()
        {
            var sha256 = SHA256.Create();
            var json = JsonSerializer.Serialize(Data);
            var finaldata = "";
            if (PreviousHash == null)
            {
                Mine(Nonce);
                finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-[]";
            }
            else
            {
                Mine(3);
            if (PreviousHash != null)
            {
                 foreach (var field in Data)
                    {
                        var grant = "GRANT";
                        var Buy = "BUY";
                        var corr = grant.Equals(field.ttInfo.ToString());
                        var corr1 = Buy.Equals(field.ttInfo.ToString());
                        if (corr)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":2,\"Amount\":" + field.v2 + ",\"Item\":\"\"" + field.p + "}]";
                        }
                        else if (corr1)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":0,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }
                        else
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":1,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }

                    }
            }
        }
            
            var inputString = finaldata;
            var inputBytes = Encoding.ASCII.GetBytes(inputString);
            var outputBytes = sha256.ComputeHash(inputBytes);
            var oo = Convert.ToBase64String(outputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        public void Mine(int difficulty)
        {
            var finaldata = "";
            var sha256 = SHA256.Create();
            var oo = "";
            var strings = "";
            for(int i=1;i<=difficulty;i++)
            {
                strings = strings + "C";
            }
           

            if(PreviousHash==null)
            {
                Nonce = difficulty;
                do {
                    
                    finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-[]";
                    var inputString = finaldata; // TODO
                    var inputBytes = Encoding.ASCII.GetBytes(inputString);
                    var outputBytes = sha256.ComputeHash(inputBytes);
                    oo = Convert.ToBase64String(outputBytes);
                    Nonce++;

                } while (!oo.StartsWith("CC"));

            }
            else
            {
                do
                {
                    foreach (var field in Data)
                    {
                        var grant = "GRANT";
                        var Buy = "BUY";
                        var corr = grant.Equals(field.gRANT.ToString());
                        var corr1 = Buy.Equals(field.gRANT.ToString());
                        if (corr)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":2,\"Amount\":" + field.v2 + ",\"Item\":\"\"" + field.p + "}]";
                        }
                        else if (corr1)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":0,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }
                        else
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":1,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }

                    }
                    var inputString = finaldata; 
                    var inputBytes = Encoding.ASCII.GetBytes(inputString);
                    var outputBytes = sha256.ComputeHash(inputBytes);
                    oo = Convert.ToBase64String(outputBytes);
                    Nonce++;
                } while (!oo.StartsWith(strings));

                

            }
    }
}
