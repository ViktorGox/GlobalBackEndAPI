using CustomConsole;
using GlobalBackEndAPI.EncryptionHandling;

namespace GlobalBackEndAPI.Encryption
{
    public class BasicEncryption : IEncryption
    {
        public string Decrypt(string toDecrypt)
        {
            CConsole.WriteSuccess("hee yaw");
            return toDecrypt;
        }

        public string Encrypt(string toEncrypt)
        {
            throw new NotImplementedException();
        }
    }
}
