using System;
using System.Security.Cryptography;
using System.Text;

namespace ChapeauService;

public class SaltAndHashService
{
    //Generates a random salt using RNGCryptoServiceProvider
    public string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }

        //Converts the salt bytes to string
        string salt = Convert.ToBase64String(saltBytes);
        return salt;
    }

    //Hashes a password using the SHA256 algorithim 
    public string HashPassword(string password, string salt)
    {
        //combines password with salt
        string passwordWithSalt = password + salt;

        using (SHA256 sha256 = SHA256.Create())
        {
            //Creates the hash with password and salt
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));
            //converts hash to string
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }
    }
}