using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void txb_nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nome = txb_nome.Text.Trim();
            btn_login.IsEnabled = !string.IsNullOrEmpty(nome);
        }

        private void btn_login_Click_1(object sender, RoutedEventArgs e)
        {
            var JogadorName = txb_nome.Text.Trim();

            if (!string.IsNullOrEmpty(JogadorName))
            {
                Pergunta1 pgPerguntas = new Pergunta1(JogadorName);
                NavigationService.Navigate(pgPerguntas);
            }
            else
            {
                MessageBox.Show("Insira seu nome!");
            }

        }
    }
}