namespace GlobalBackEndAPI.EncryptionHandling
{
    /// <summary>
    /// Simple interface which implements <see cref="Encrypt(string)"/> and a <see cref="Decrypt(string)"/> methods. Methods return the base 64 version of the text.
    /// </summary>
    public interface IEncryption
    {
        /// <summary>
        /// Takes in string to encrypt. Returns base 64 string.
        /// </summary>
        string Encrypt(string toEncrypt);
        /// <summary>
        /// Takes in base 64 string to decrypt. Returns the decrypted string.
        /// </summary>
        string Decrypt(string toDecrypt);
    }
}
