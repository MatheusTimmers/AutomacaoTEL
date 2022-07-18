using Newtonsoft.Json;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using AutomaçãoTEL;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace AutomaçãoTEL
{
    public class User
    {
        public string NameUser { get; private set; }
        public string PasswordUser { get; private set; }


        public User(string nameUser, string passwordUser)
        {
            NameUser = nameUser;
            PasswordUser = GenerateHashMd5(passwordUser);
        }

        public static string GenerateHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }



        public void CreateUser(object User)
        {
            DataBaseAutentificator autentificator = new DataBaseAutentificator();
            autentificator.ExecuteManipulation(CommandType.Text, $"INSERT INTO UserData(NAME, USERPASSWORD)" +
                                                                 $"VALUES ('{NameUser}','{PasswordUser}');");
        }

        public bool Login(Object User)
        {
            DataBaseAutentificator autentificator = new DataBaseAutentificator();
            autentificator.ExecuteManipulation(CommandType.Text, $"SELECT NAME, NAME" +
                                                                 $"WHERE NAME = '{NameUser}' AND USERPASSWORD = '{PasswordUser}');");
        }


        public bool CompareMD5(string passWordDB, string PW_MD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var PW = GenerateHashMd5(passWordDB);
                if (ChecksHash(md5Hash, PW_MD5, PW))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool ChecksHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
