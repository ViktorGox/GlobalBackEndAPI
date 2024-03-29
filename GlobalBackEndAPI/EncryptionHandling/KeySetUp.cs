namespace GlobalBackEndAPI.EncryptionHandling
{
    public class KeySetUp
    {
        /// <summary>
        /// Accesses the key.key file and takes the key from it, then removes the contents. Thus the key is only accessible once. The key must be replaced on every start up.
        /// Throws <see cref="FileNotFoundException"/> if the file is not present.
        /// Throws <see cref="ArgumentException"/> if the file is empty.
        /// </summary>
        public static string GetKey()
        {
            string filePath = @".\Key\key.key";

            try
            {
                string fileContents = File.ReadAllText(filePath);
                if(fileContents.Length == 0)
                {
                    throw new ArgumentException("A key was not placed, or was not re-entered. Everytime the key is read, the contents of the file are deleted.");
                }
                //File.WriteAllText(filePath, string.Empty);
                return fileContents;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("A security key is required for the encryption and decryption. Create a file named key.key inside the Key folder and place the key inside.");
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
