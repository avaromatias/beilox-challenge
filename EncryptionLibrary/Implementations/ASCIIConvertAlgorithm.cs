using EncryptionLibrary.Interfaces;
using System;

namespace EncryptionLibrary.Implementations
{
    public class ASCIIConvertAlgorithm : ISecurityElement
    {
        private readonly Func<int, int> _decryptionMethod;
        private readonly Func<int, int> _encryptionMethod;

        public ASCIIConvertAlgorithm(Func<int, int> decryptionMethod, Func<int, int> encryptionMethod)
        {
            _decryptionMethod = decryptionMethod;
            _encryptionMethod = encryptionMethod;
        }

        public string Decrypt(string text)
        {
            int index = 0;
            var result = text.ToCharArray();
            foreach (var character in text)
            {
                result[index] = (char)_decryptionMethod(character);
                index++;
            }

            return new string(result);
        }

        public string Encrypt(string text)
        {
            int index = 0;
            var result = text.ToCharArray();
            foreach (var character in text)
            {
                result[index] = (char)_encryptionMethod(character);
                index++;
            }

            return new string(result);
        }
    }
}
