using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;


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
            var num = 1;
            lab_per1.Content += $" {num++}";

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

            // Consulta para obter a alternativa B
            string sqlB = $"select opB from perguntas where PerguntasID = {1}";
            MySqlCommand cmdB = new MySqlCommand(sqlB, ConexaoDB.Conexao);
            MySqlDataReader readerB = cmdB.ExecuteReader();
            if (readerB.Read())
            {
                alternativa_B.Text = readerB["opB"].ToString();
            }
            readerB.Close();

            // Consulta para obter a alternativa C
            string sqlC = $"select opC from perguntas where PerguntasID = {1}";
            MySqlCommand cmdC = new MySqlCommand(sqlC, ConexaoDB.Conexao);
            MySqlDataReader readerC = cmdC.ExecuteReader();
            if (readerC.Read())
            {
                alternativa_C.Text = readerC["opC"].ToString();
            }
            readerC.Close();

            // Consulta para obter a alternativa D
            string sqlD = $"select opD from perguntas where PerguntasID = {1}";
            MySqlCommand cmdD = new MySqlCommand(sqlD, ConexaoDB.Conexao);
            MySqlDataReader readerD = cmdD.ExecuteReader();
            if (readerD.Read())
            {
                alternativa_D.Text = readerD["opD"].ToString();
            }
            readerD.Close();

            int tempoRestante = 30; // Tempo inicial em segundos 
            DispatcherTimer cronometro = new DispatcherTimer();
            cronometro.Interval = TimeSpan.FromSeconds(1); // Atualiza a cada segundo
            EventHandler value = (sender, e) =>
            {
                tempoRestante--;
                lb_Tempo.Content = $"{tempoRestante}s"; // Atualiza o label 
                if (tempoRestante <= 0)
                {
                    cronometro.Stop();
                }
            };

            cronometro.Tick += value;
            cronometro.Start();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
