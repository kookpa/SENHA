using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace senha
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
        public static class PasswordGenerator
        {
            private static readonly Random random = new Random();
            public static string Generate(int length, bool includeLetters, bool includeNumbers, bool includeSpecialChars)
            {
                const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string numbers = "0123456789";
                const string specialChars = "!@#$%^&*()_+-=[]{};:,.<>?";

                var chars = string.Concat(
               includeLetters ? letters : "",
               includeNumbers ? numbers : "",
               includeSpecialChars ? specialChars : "");

                return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            
        }

        private void txbSenha_TextChanged(object sender, EventArgs e)
        {
            var password = PasswordGenerator.Generate(12, true, true, true);
            TextBoxManager.btnAdd(password, txbSenha);
            TextBoxManager.btnRemover(5, txbSenha);
        }
        public static class TextBoxManager
        {
            public static void btnAdd(string btnAdd, System.Windows.Forms.TextBox txbSenha)
            {
                txbSenha.Text += btnAdd;
            }
            public static void btnRemover(int btnRemover, System.Windows.Forms.TextBox txbSenha)
            {
                if (btnRemover > txbSenha.Text.Length)
                {
                    throw new ArgumentException("Length to remove is greater than the length of the text in the TextBox.");
                }
                txbSenha.Text = txbSenha.Text.Substring(0, txbSenha.Text.Length - btnRemover);
            }
        }
    }
}
