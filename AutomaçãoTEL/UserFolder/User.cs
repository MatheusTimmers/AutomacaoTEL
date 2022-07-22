using Newtonsoft.Json;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using AutomaçãoTEL;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using Windows.Graphics.Imaging;

namespace AutomaçãoTEL.UserFolder
{
    public class User
    {
        public string NameUser { get; private set; }
        public string PasswordUser { get; private set; }
        public SoftwareBitmapSource BitmapSource { get; private set; }


        public User(string nameUser, string passwordUser, SoftwareBitmapSource bitmapSource)
        {
            NameUser = nameUser;
            PasswordUser = GenerateHashMd5(passwordUser);
            BitmapSource = bitmapSource;
        }

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



        public void CreateUser()
        {
            DataBaseAutentificator autentificator = new DataBaseAutentificator();
            autentificator.ExecuteCommand(CommandType.Text, $"INSERT INTO UserData(NAME, USERPASSWORD, USERIMAGE)" +
                                                                 $"VALUES ('{NameUser}','{PasswordUser}','{BitmapSource}');");
        }

        public bool Login()
        {
            DataBaseAutentificator autentificator = new DataBaseAutentificator();
            var query = autentificator.ExecuteQuery(CommandType.Text, $"SELECT NAME, USERPASSWORD FROM UserData" +
                                                                $" WHERE NAME = '{NameUser}' AND USERPASSWORD = '{PasswordUser}';");
            if (query.Rows.Count == 0)
            {
                return false;
            }
            return true;     
            
        }

        public int LoadImage()
        {
            DataBaseAutentificator autentificator = new DataBaseAutentificator();
            var query = autentificator.ExecuteQuery(CommandType.Text, $"SELECT USERIMAGE FROM UserData" +
                                                                $" WHERE NAME = '{NameUser}' AND USERPASSWORD = '{PasswordUser}';");

            FileInfo arqImagem = new FileInfo(query.Rows[0].ToString());
            long tamanhoArquivoImagem = arqImagem.Length;
            FileStream fs = new FileStream(query.Rows[0].ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] vetorImagens = new byte[Convert.ToInt32(tamanhoArquivoImagem)];
            int iBytesRead = fs.Read(vetorImagens, 0, Convert.ToInt32(tamanhoArquivoImagem));
            fs.Close();
            return iBytesRead;

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
