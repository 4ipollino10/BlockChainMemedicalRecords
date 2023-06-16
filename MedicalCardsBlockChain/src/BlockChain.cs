using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalCardsBlockChain.src
{
    internal class BlockChain
    {
        /// <summary>
        /// список блоков
        /// </summary>
        public List<PatientCard> Blocks { get; private set; }

        /// <summary>
        /// последний блок
        /// </summary>
        public PatientCard LastBlock { get; private set; }

        /// <summary>
        /// создание цепочки блоков
        /// </summary>
        public BlockChain() 
        {
            Blocks = new List<PatientCard>();
            var genesisBlock = new PatientCard();

            Blocks.Add(genesisBlock);
            LastBlock = genesisBlock;

        }

        /// <summary>
        /// добавление нового блока в цепочку
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        public void AddCard(string data, string user)
        {
            var card = new PatientCard(data, user, LastBlock);
            Blocks.Add(card);
            LastBlock = card;
            //Console.WriteLine($"last block hash = {LastBlock.Hash}");
        }

        /// <summary>
        /// проверка цепочки на корректность данных
        /// </summary>
        /// <returns> true - корректна, false - некорректна</returns>
        public bool VerifyChain()
        {
            var genesisBlock = new PatientCard();

            foreach (var block in Blocks.Skip(1)) 
            {
                if(genesisBlock.Hash != block.PrevHash)
                {
                    return false;
                }
                genesisBlock = block;
            }

            return true;
        }

    }
}
