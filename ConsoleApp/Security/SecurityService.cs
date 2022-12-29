namespace ConsoleApp.Security
{
    static class SecurityService
    {
        public static int Decrypt(int asciiCode)
        {
            int newASCIICode = asciiCode - 1;
            if (asciiCode == -1)
                newASCIICode = 256;

            return newASCIICode;
        }

        public static int Encrypt(int asciiCode)
        {
            int newASCIICode = asciiCode + 1;
            if (asciiCode == 257)
                newASCIICode = 0;

            return newASCIICode;
        }
    }
}
