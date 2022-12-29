using ConsoleApp.Security;
using EncryptionLibrary.Implementations;
using EncryptionLibrary.Interfaces;

class Program
{
    static void Main()
    {
        var algorithms = new List<ISecurityElement>()
        {
            new ReverseAlgorithm(),
            new ASCIIConvertAlgorithm(SecurityService.Decrypt, SecurityService.Encrypt),
            new RecursiveAlgorithm()
        };

        Console.Write("Enter the phrase to encrypt: ");
        var phrase = Console.ReadLine();

        ISecurityElement algorithm = algorithms.FirstOrDefault();
        var encryptedPhraseTemp = phrase;
        var decryptedPhraseTemp = "";
        int index = 0;

        Console.WriteLine();
        Console.WriteLine("############ STARTING TO ENCRYPT... ############");

        while (index != algorithms.Count)
        {
            Console.WriteLine($"---------------{algorithm.GetType().Name}---------------");
            var encryptedPhrase = algorithm.Encrypt(encryptedPhraseTemp);
            Console.WriteLine($"Encrypted phrase: {encryptedPhrase}");
            Console.WriteLine();

            encryptedPhraseTemp = encryptedPhrase;

            if (algorithms.LastOrDefault() == algorithm)
                decryptedPhraseTemp = encryptedPhrase;

            index++;
            if (index < algorithms.Count)
                algorithm = algorithms[index];
        }

        index--;
        Console.WriteLine("############ STARTING TO DECRYPT... ############");

        while (index >= 0)
        {
            Console.WriteLine($"---------------{algorithm.GetType().Name}---------------");
            var decryptedPhrase = algorithm.Decrypt(decryptedPhraseTemp);
            Console.WriteLine($"Decrypted phrase: {decryptedPhrase}");
            Console.WriteLine();

            decryptedPhraseTemp = decryptedPhrase;

            index--;

            if (index >= 0)
                algorithm = algorithms[index];
        }
    }
}