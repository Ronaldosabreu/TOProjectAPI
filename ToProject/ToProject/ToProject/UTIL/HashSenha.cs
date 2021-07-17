using CryptSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToProject.UTIL
{
    public class HashSenha
    {

        public string Codifica(string senha)
        {
            return Crypter.MD5.Crypt(senha);
        }

        public bool Compara(string senha, string hash)
        {
            return Crypter.CheckPassword(senha, hash);
        }


    }
}
