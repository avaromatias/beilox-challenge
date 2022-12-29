using EncryptionLibrary.Interfaces;
using System;

namespace EncryptionLibrary.Implementations
{
    public class ReverseAlgorithm : ISecurityElement
    {
        public string Decrypt(string text)
        {
            return Reverse(text);
        }

        public string Encrypt(string text)
        {
            return Reverse(text);
        }

        private string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
