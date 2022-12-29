using EncryptionLibrary.Interfaces;

namespace EncryptionLibrary.Implementations
{
    public class RecursiveAlgorithm : ISecurityElement
    {
        public string Decrypt(string text)
        {
            if (text.Length == 0) return "";

            var charArray = text.ToCharArray();
            int offset = 5;

            int lastIndex = charArray.Length - 1;
            int newAscii = charArray[lastIndex] - offset;
            charArray[lastIndex] = (char)newAscii;
            return Decrypt(new string(charArray).Substring(0, lastIndex)) + charArray[lastIndex];
        }

        public string Encrypt(string text)
        {
            if (text.Length == 0) return "";

            var charArray = text.ToCharArray();
            int offset = 5;

            int lastIndex = charArray.Length - 1;
            int newAscii = charArray[lastIndex] + offset;
            charArray[lastIndex] = (char)newAscii;
            return Encrypt(new string(charArray).Substring(0, lastIndex)) + charArray[lastIndex];
        }
    }
}
