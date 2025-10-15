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
            string nome = txb_nome.Text.Trim();
            RegistrarJogador(nome);  // Agora sim, registra ao clicar
            NavigationService.Navigate(new Pergunta1());
        }

        private void RegistrarJogador(string nome)
        {
            string sql = "INSERT INTO jogador (Nome) VALUES (@nome)";
            using (MySqlCommand cmd = new MySqlCommand(sql, ConexaoDB.Conexao))
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.ExecuteNonQuery();
            }
        }

      
    }       
}