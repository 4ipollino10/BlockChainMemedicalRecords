using MedicalCardsBlockChain.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCardsBlockChain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chain = new BlockChain();

            chain.AddCard("new block", "loh");
            chain.AddCard("asdfdas", "lo1h");
            chain.AddCard("kto eto", "loasdfh");
            chain.AddCard("block", "lo123h");


            foreach (var card in chain.Blocks)
            {
                Console.WriteLine($"card hash = {card.Hash}\nprev hash = {card.PrevHash}\n");

            }

            chain.LastBlock.PrevHash = "111";
            Console.WriteLine($"is chain correct: {chain.VerifyChain()}");

        }
    }
}
