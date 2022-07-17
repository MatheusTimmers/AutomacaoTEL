using Newtonsoft.Json;
using System.IO;

namespace AutomaçãoTEL
{
    public class User
    {
        public string NameUser { get; private set; }
        public string PasswordUser { get; private set; }


        public User(string nameUser,string passwordUser)
        {
            NameUser = nameUser;
            PasswordUser = passwordUser;
        }


        public void CreateUser(object User)
        {
            string fileName = @"C:\Users\mathe\Downloads\teste.json";
            string jsonString = JsonConvert.SerializeObject(User);
            File.WriteAllText(fileName, jsonString);
        }

       

    }
}
