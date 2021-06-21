using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    // sadrži metode za rad s datotekom koje su potrebne kroz aplikaciju
    public class FileHelper
    {
        const string fileName = "database.txt";
        // vraća jedan znak A-Z
        public static string GetPepperValue()
        {
            // 65 je 'A' u ascii tablici
            return ((char)(65 + (GetCount() % 26))).ToString();
        }

        // vraća broj zapisa u bazi, o njemu ovisi koji će se znak koristiti za generiranje papra
        public static int GetCount()
        {
            return File.ReadLines(fileName).Count();
        }

        // sprema korisnika u bazu na kraj datoteke
        public static void StoreUser(User user)
        {
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(GenerateLine(user));
            }
        }

        // objekt korisnika pretvara u string koji odgovata formatu datoteke
        private static string GenerateLine(User user)
        {
            return $"{user.UserName},{user.Salt},{user.PwdHash},{user.PwdHashSalt},{user.PwdHashPepper}";
        }

        // pretvara string iz baze u objekt korisnika
        public static User GetUserFromLine(string line)
        {
            var values = line.Split(',');
            return new User
            {
                UserName = values[0],
                Salt = values[1],
                PwdHash = values[2],
                PwdHashSalt = values[3],
                PwdHashPepper = values[4],
            };
        }

        // provjerava postoji li već korisničko ime u bazi
        internal static bool CheckUsername(string username)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.ToUpper().StartsWith(username.ToUpper()))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        // provjerava username i lozinku
        internal static bool CheckLogin(string username, string hash, string type)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.ToUpper().StartsWith(username.ToUpper()))
                        {
                            var user = GetUserFromLine(line);
                            if(type == "login")
                            {
                                return user.PwdHash == hash;
                            }
                            if(type == "salt")
                            {
                                return user.PwdHashSalt == hash;
                            }
                            if(type == "pepper")
                            {
                                return user.PwdHashPepper == hash;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static string GetSalt(string username)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.ToUpper().StartsWith(username.ToUpper()))
                        {
                            var user = GetUserFromLine(line);
                            return user.Salt;
                        }
                    }
                }
            }
            return "";
        }
    }
}
