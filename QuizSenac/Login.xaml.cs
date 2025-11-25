using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace QuizSenac
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

            // permite capturar o Enter
            this.KeyDown += Window_KeyDown;
            this.Focusable = true;
            this.Loaded += (s, e) => this.Focus();
        }

        private void txb_nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nome = txb_nome.Text.Trim();
            btn_login.IsEnabled = !string.IsNullOrEmpty(nome);
        }

        private void btn_login_Click_1(object sender, RoutedEventArgs e)
        {
            teste();
        }

        private void teste()
        {
            var JogadorName = txb_nome.Text.Trim();

            if (!string.IsNullOrEmpty(JogadorName))
            {
                Pergunta1 pgPerguntas = new Pergunta1(JogadorName);
                NavigationService.Navigate(pgPerguntas);
            }
            else
            {
                MessageBox.Show("Nome inválido. \nPor Favor insira seu nome!");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // chama exatamente o clique do botão
                btn_login_Click_1(btn_login, null);
            }
        }
    }
}
