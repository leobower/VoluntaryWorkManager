using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography 
{
    public class CustomCrypto : ICryptography
    {
        private byte[] _keyByte = { };

        private static string _key = "Pass@123";

        //Default Initial vector
        private byte[] _ivByte = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };

        private const int ADDDAY = -37;
        private const int ADDMON = 63;
        private const int ADDYEAR = -57;

        private const int ADDHOUR = 13;
        private const int ADDMIN = -18;
        private const int ADDSEC = 7;
        public enum HashName
        {
            SHA1 = 1,
            MD5 = 2,
            SHA256 = 4,
            SHA384 = 8,
            SHA512 = 16
        }

        private string Encrypter(string pValue, string pKey, string pIV)
        {
            string encryptValue = String.Empty;
            MemoryStream ms = null;
            CryptoStream cs = null;
            try
            {
                if (!String.IsNullOrEmpty(pValue))
                {
                    if (!string.IsNullOrEmpty(pKey))
                    {
                        _keyByte = Encoding.UTF8.GetBytes(pKey.Substring(0, 8));
                        if (!String.IsNullOrEmpty(pIV))
                        {
                            _ivByte = Encoding.UTF8.GetBytes(pIV.Substring(0, 8));
                        }
                    }
                    else
                    {
                        _keyByte = Encoding.UTF8.GetBytes(_key);
                    }

                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        byte[] inputByteArray = Encoding.UTF8.GetBytes(pValue);
                        using (ms = new MemoryStream())
                        {
                            using (cs = new CryptoStream(ms, des.CreateEncryptor(_keyByte, _ivByte), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                encryptValue = Convert.ToBase64String(ms.ToArray());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return encryptValue;
        }

        private string Decrypter(string pValue, string pKey, string pIV)
        {
            string decrptValue = string.Empty;
            if (!string.IsNullOrEmpty(pValue))
            {
                MemoryStream ms = null;
                CryptoStream cs = null;
                pValue = pValue.Replace(" ", "+");
                byte[] inputByteArray = new byte[pValue.Length];
                try
                {
                    if (!string.IsNullOrEmpty(pKey))
                    {
                        _keyByte = Encoding.UTF8.GetBytes
                                (pKey.Substring(0, 8));
                        if (!string.IsNullOrEmpty(pIV))
                        {
                            _ivByte = Encoding.UTF8.GetBytes
                                (pIV.Substring(0, 8));
                        }
                    }
                    else
                    {
                        _keyByte = Encoding.UTF8.GetBytes(_key);
                    }
                    using (DESCryptoServiceProvider des =
                            new DESCryptoServiceProvider())
                    {
                        inputByteArray = Convert.FromBase64String(pValue);
                        ms = new MemoryStream();
                        cs = new CryptoStream(ms, des.CreateDecryptor
                        (_keyByte, _ivByte), CryptoStreamMode.Write);
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        Encoding encoding = Encoding.UTF8;
                        decrptValue = encoding.GetString(ms.ToArray());
                    }
                }
                catch
                {
                    //TODO: write log 
                }
                finally
                {
                    cs.Dispose();
                    ms.Dispose();
                }
            }
            return decrptValue;
        }


        public string Decrypt(string value)
        {
            return Decrypter(value, string.Empty, string.Empty);
        }

       
        public string Encrypt(string value)
        {
            return Encrypter(value, String.Empty, String.Empty);
        }


        #region COMPUTER HASH

        public string ComputeHash(string plainText, string salt)
        {
            return ComputeHash(plainText, salt, HashName.MD5);
        }

        private string ComputeHash(string plainText, string salt, HashName hashName)
        {
            if (!string.IsNullOrEmpty(plainText))
            {
                // Convert plain text into a byte array. 
                byte[] plainTextBytes = ASCIIEncoding.ASCII.GetBytes(plainText);
                // Allocate array, which will hold plain text and salt. 
                byte[] plainTextWithSaltBytes = null;
                byte[] saltBytes;
                if (!string.IsNullOrEmpty(salt))
                {
                    // Convert salt text into a byte array. 
                    saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
                    plainTextWithSaltBytes =
                        new byte[plainTextBytes.Length + saltBytes.Length];
                }
                else
                {
                    // Define min and max salt sizes. 
                    int minSaltSize = 4;
                    int maxSaltSize = 8;
                    // Generate a random number for the size of the salt. 
                    Random random = new Random();
                    int saltSize = random.Next(minSaltSize, maxSaltSize);
                    // Allocate a byte array, which will hold the salt. 
                    saltBytes = new byte[saltSize];
                    // Initialize a random number generator. 
                    RNGCryptoServiceProvider rngCryptoServiceProvider =
                                new RNGCryptoServiceProvider();
                    // Fill the salt with cryptographically strong byte values. 
                    rngCryptoServiceProvider.GetNonZeroBytes(saltBytes);
                }
                // Copy plain text bytes into resulting array. 
                for (int i = 0; i < plainTextBytes.Length; i++)
                {
                    plainTextWithSaltBytes[i] = plainTextBytes[i];
                }
                // Append salt bytes to the resulting array. 
                for (int i = 0; i < saltBytes.Length; i++)
                {
                    plainTextWithSaltBytes[plainTextBytes.Length + i] =
                                        saltBytes[i];
                }
                HashAlgorithm hash = null;
                switch (hashName)
                {
                    case HashName.SHA1:
                        hash = new SHA1Managed();
                        break;
                    case HashName.SHA256:
                        hash = new SHA256Managed();
                        break;
                    case HashName.SHA384:
                        hash = new SHA384Managed();
                        break;
                    case HashName.SHA512:
                        hash = new SHA512Managed();
                        break;
                    case HashName.MD5:
                        hash = new MD5CryptoServiceProvider();
                        break;
                }
                // Compute hash value of our plain text with appended salt. 
                byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
                // Create array which will hold hash and original salt bytes. 
                byte[] hashWithSaltBytes =
                    new byte[hashBytes.Length + saltBytes.Length];
                // Copy hash bytes into resulting array. 
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hashWithSaltBytes[i] = hashBytes[i];
                }
                // Append salt bytes to the result. 
                for (int i = 0; i < saltBytes.Length; i++)
                {
                    hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
                }
                // Convert result into a base64-encoded string. 
                string hashValue = Convert.ToBase64String(hashWithSaltBytes);
                // Return the result. 
                return hashValue;
            }
            return string.Empty;
        }

        #endregion

        #region CUSTOM CODER

        public string DateCoder(DateTime pDate)
        {
            DateTime newDate = pDate.AddDays(ADDDAY);
            newDate = newDate.AddMonths(ADDMON);
            newDate = newDate.AddYears(ADDYEAR);
            newDate = newDate.AddHours(ADDHOUR);
            newDate = newDate.AddMinutes(ADDMIN);
            newDate = newDate.AddSeconds(ADDSEC);

            string retorno = this.Encrypt(newDate.ToString("dd/MM/yyyy hh:mm:ss"));
            return retorno;
        }

        public DateTime DateDecode(string pDateEncrypt)
        {
            DateTime retorno = DateTime.MinValue;
            string dateDecrypt = this.Decrypt(pDateEncrypt);
            if (!DateTime.TryParse(dateDecrypt, out retorno))
            {
                throw new InvalidCastException();
            }

            return DateTime.MinValue;
        }

        #endregion

    }
}
