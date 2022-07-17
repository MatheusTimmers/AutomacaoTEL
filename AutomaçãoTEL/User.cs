using Newtonsoft.Json;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using AutomaçãoTEL;
using System.Data;

namespace AutomaçãoTEL
{
    public class User
    {
        public string NameUser { get; private set; }
        public string PasswordUser { get; private set; }


        public User(string nameUser, string passwordUser)
        {
            NameUser = nameUser;
            PasswordUser = passwordUser;
        }


        public void CreateUser(object User)
        {
            DataBaseAutentificator autentificator = new DataBaseAutentificator();
            autentificator.ExecuteManipulation(CommandType.Text, NameUser);

        }

    }
}
