using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography
{ 
    public interface ICryptography
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}
