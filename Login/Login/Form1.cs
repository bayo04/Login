using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        private const string _url = "https://localhost:44365/Account/";

        public Form1()
        {
            InitializeComponentAsync();
        }

        // event kod klika buttona za login
        private void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            var url = _url + $"Login?username={txtUsername.Text}&hash={GetHashString(txtPassword.Text)}";

            CallApiAsync(url);
        }

        // event kod klika buttona za registraciju
        private void btnRegister_ClickAsync(object sender, EventArgs e)
        {
            var url = _url + $"Register?username={txtUsername.Text}&password={txtPassword.Text}";

            CallApiAsync(url);
        }

        // event kod klika buttona za login saltom
        private void btnLoginSalt_ClickAsync(object sender, EventArgs e)
        {
            CallSaltApiAsync(txtUsername.Text, txtPassword.Text);
        }

        // event kod klika buttona za login pepperom
        private void btnLoginPepper_ClickAsync(object sender, EventArgs e)
        {
            CallPepperApiAsync(txtUsername.Text, txtPassword.Text);
        }

        // poziva api te izbacuje messageBox ovisno o uspješnosti
        private async Task CallApiAsync(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url, null);
            var result = await response.Content.ReadAsStringAsync();

            if (result == "true")
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("Unsuccessful");
            }
        }

        // poziva api (generira sve varijacije za pepper) te izbacuje messageBox ovisno o uspješnosti
        private async Task CallPepperApiAsync(string username, string password)
        {
            for (var i = 65; i <= 91; i++)
            {
                var url = _url + $"LoginPepper?username={username}&hash={GetHashString(password + (char)i)}";

                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, null);
                var result = await response.Content.ReadAsStringAsync();

                if (result == "true")
                {
                    MessageBox.Show("Successful");
                    return;
                }
            }
            MessageBox.Show("Unsuccessful");
        }



        // poziva api (dohvaća salt s apija te spaja ga s lozinkom) te izbacuje messageBox ovisno o uspješnosti
        private async Task CallSaltApiAsync(string username, string password)
        {
            HttpClient client = new HttpClient();
            var responseSalt = await client.PostAsync(_url + $"GetSalt?username={username}", null);
            var salt = await responseSalt.Content.ReadAsStringAsync();

            var url = _url + $"LoginSalt?username={username}&hash={GetHashString(password + salt)}";

            client = new HttpClient();
            var response = await client.PostAsync(url, null);
            var result = await response.Content.ReadAsStringAsync();

            if (result == "true")
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("Unsuccessful");
            }
        }

        // dobivanje bajtova iz stringa, ne koristi se nigdje osim u metodi ispod
        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        // dobivanje hasha iz stringa
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
