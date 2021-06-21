using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BruteForce
{
    public partial class Form1 : Form
    {
        private const string _url = "https://localhost:44365/Account/";

        public Form1()
        {
            InitializeComponent();
            txtPath.Text = @"C:\Users\Antonio\source\repos\Matija\lozinke.txt";
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            BruteHash();
        }

        private async Task BruteHash()
        {
            lblLoading.Text = "Učitavanje";
            using (var fileStream = File.OpenRead(txtPath.Text))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    string username = txtUsername.Text;
                    int i = 1;
                    //provjerava na koju krajnju točku će napadati
                    string urlExtension = "Login";
                    if (rdbSalt.Checked)
                    {
                        urlExtension += "Salt";
                    }
                    if (rdbPepper.Checked)
                    {
                        urlExtension += "Pepper";
                    }
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lblLoading.Text = $"Učitavanje: {i}";
                        var url = _url + $"{urlExtension}?username={username}&hash={GetHashString(line)}";
                        HttpClient client = new HttpClient();
                        var response = await client.PostAsync(url, null);
                        var result = await response.Content.ReadAsStringAsync();

                        if (result == "true")
                        {
                            MessageBox.Show($"Username: {username}, lozinka: {line}");
                            lblLoading.Text = "";
                            return;
                        }
                        i++;
                    }
                    lblLoading.Text = "";
                    MessageBox.Show($"Nije pronađena lozinka");
                }
            }
        }

        private void btnSalt_Click(object sender, EventArgs e)
        {
            BruteSalt();
        }

        private async Task BruteSalt()
        {
            lblLoading.Text = "Učitavanje";
            using (var fileStream = File.OpenRead(txtPath.Text))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    string username = txtUsername.Text;
                    int i = 1;
                    string salt = await GetSalt();
                    //provjerava na koju krajnju točku će napadati
                    string urlExtension = "Login";
                    if (rdbSalt.Checked)
                    {
                        urlExtension += "Salt";
                    }
                    if (rdbPepper.Checked)
                    {
                        urlExtension += "Pepper";
                    }
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lblLoading.Text = $"Učitavanje: {i}";
                        var url = _url + $"{urlExtension}?username={username}&hash={GetHashString(line + salt)}";
                        HttpClient client = new HttpClient();
                        var response = await client.PostAsync(url, null);
                        var result = await response.Content.ReadAsStringAsync();

                        if (result == "true")
                        {
                            MessageBox.Show($"Username: {username}, lozinka: {line}");
                            lblLoading.Text = "";
                            return;
                        }
                        i++;
                    }
                    lblLoading.Text = "";
                    MessageBox.Show($"Nije pronađena lozinka");
                }
            }
        }

        private async Task<string> GetSalt()
        {
            HttpClient client = new HttpClient();
            var responseSalt = await client.PostAsync(_url + $"GetSalt?username={txtUsername.Text}", null);
            return await responseSalt.Content.ReadAsStringAsync();
        }

        private void btnPepper_Click(object sender, EventArgs e)
        {
            BrutePepper();
        }

        private async Task BrutePepper()
        {
            lblLoading.Text = "Učitavanje";
            using (var fileStream = File.OpenRead(txtPath.Text))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    string username = txtUsername.Text;
                    int i = 1;
                    //provjerava na koju krajnju točku će napadati
                    string urlExtension = "Login";
                    if (rdbSalt.Checked)
                    {
                        urlExtension += "Salt";
                    }
                    if (rdbPepper.Checked)
                    {
                        urlExtension += "Pepper";
                    }
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lblLoading.Text = $"Učitavanje: {i}";

                        for (var j = 65; j <= 91; j++)
                        {
                            var url = _url + $"{urlExtension}?username={username}&hash={GetHashString(line + (char)j)}";
                            HttpClient client = new HttpClient();
                            var response = await client.PostAsync(url, null);
                            var result = await response.Content.ReadAsStringAsync();

                            if (result == "true")
                            {
                                MessageBox.Show($"Username: {username}, lozinka: {line}");
                                lblLoading.Text = "";
                                return;
                            }
                        }
                            
                        i++;
                    }
                    lblLoading.Text = "";
                    MessageBox.Show($"Nije pronađena lozinka");
                }
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
