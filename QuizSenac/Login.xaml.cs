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

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
//<<<<<<< HEAD
            NavigationService.Navigate(new BemVindo());
        }

        private void txb_nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            
//=======
            string sql = "select * from Perguntas";

            MySqlCommand cmd = new MySqlCommand(sql, ConexaoDB.Conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            MessageBox.Show("Perunta: " + reader["Pergunta"]);
//>>>>>>> cb1873074b2250e36b22dce954e8eeaf54befc46
        }
    }
}
