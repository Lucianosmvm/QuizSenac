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
using MySql.Data.MySqlClient;

namespace QuizSenac
{
    /// <summary>
    /// Interação lógica para Pergunta1.xam
    /// </summary>
    public partial class Pergunta1 : Page
    {
        public Pergunta1()
        {
            InitializeComponent();

            // Consulta para obter a pergunta
            string sql = $"select Pergunta from perguntas where PerguntasID = {1}";
            MySqlCommand cmd = new MySqlCommand(sql, ConexaoDB.Conexao);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_pergunta.Text = reader["Pergunta"].ToString();
            }
            reader.Close();

            // Consulta para obter a alternativa A
            string sqlA = $"select opA from perguntas where PerguntasID = {1}";
            MySqlCommand cmdA = new MySqlCommand(sqlA, ConexaoDB.Conexao);
            MySqlDataReader readerA = cmdA.ExecuteReader();
            if (readerA.Read())
            {
                alternativa_A.Text = readerA["opA"].ToString();
            }
            readerA.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
