using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace MedicalCardsBlockChain.src
{
    internal class PatientCard
    {
        /// <summary>
        /// дата создания блока
        /// </summary>
        public DateTime CreationTime { get; private set; }
        
        /// <summary>
        /// какие-то данные
        /// </summary>
        public string Data { get; private set; }
        
        /// <summary>
        /// хэш блока
        /// </summary>
        public string Hash { get
            {
                return GetHash();
            } 
            private set
            {}
        }
        
        /// <summary>
        /// хэш предыдущего блока
        /// </summary>
        public string PrevHash { get; set; }
        
        /// <summary>
        /// какие-то данные о пользователе
        /// </summary>
        public string User { get; private set; }

        /// <summary>
        /// создание genesis блока
        /// </summary>
        public PatientCard()
        {
            CreationTime = DateTime.Parse("01.01.01 00:00:00.000");
            Data = "GENESIS";
            User = "genesis";
            PrevHash = "1111";
            Hash = GetHash();
        }

        /// <summary>
        /// создание нового блока
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        /// <param name="card"></param>
        public PatientCard(string data, string user, PatientCard card)
        {
            CreationTime = DateTime.UtcNow;
            Data = data;
            User = user;
            PrevHash = card.Hash;
            Hash = GetHash();
        }

        /// <summary>
        /// получение хеша блока
        /// </summary>
        /// <returns></returns>
        private string GetHash()
        {
            var data = User + Data + PrevHash + CreationTime.ToString();
            var byteData = Encoding.ASCII.GetBytes(data);
            
            using (var sha256 = SHA256.Create())
            {
                return string.Concat(sha256.ComputeHash(byteData).Select(item => item.ToString("x2")));
            }
        }

    }
}
