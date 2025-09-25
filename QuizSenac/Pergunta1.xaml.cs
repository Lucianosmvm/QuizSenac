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
        private string respostaCorreta;
        public Pergunta1()
        {


            InitializeComponent();
            var num = 1;
            lab_per1.Content += $" {num++}";
            update_pergunta();


        }


        private void update_pergunta()
        {
            // Consulta para obter a pergunta
            Random rand = new Random();
            var idx = rand.Next(1, 20);
            string sql = $"select * from perguntas where PerguntasID = {idx}";
            MySqlCommand cmd = new MySqlCommand(sql, ConexaoDB.Conexao);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                respostaCorreta = reader["respostaCorreta"].ToString();
                txt_pergunta.Text = reader["Pergunta"].ToString();
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        alternativa_A.Text = reader["opA"].ToString();
                    }
                    else if (i == 1)
                    {
                        alternativa_B.Text = reader["opB"].ToString();
                    }
                    else if (i == 2)
                    {
                        alternativa_C.Text = reader["opC"].ToString();
                    }
                    else if (i == 3)
                    {
                        alternativa_D.Text = reader["opD"].ToString();
                    }
                }
            }


            reader.Close();
            updateTime();

        }

        private void updateTime()
        {
            int tempoRestante = 5; // Tempo inicial em segundos 
            DispatcherTimer cronometro = new DispatcherTimer();

            cronometro.Start();
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
        }


        private void btn_A_Click(object sender, RoutedEventArgs e)
        {
            update_pergunta();
            if (alternativa_A.Text == respostaCorreta)
            {
                MessageBox.Show(" Resposta correta!");
            }
            else
            {
                MessageBox.Show($" Resposta errada! A correta era: {respostaCorreta}");
            }
        }

        private void btn_B_Click(object sender, RoutedEventArgs e)
        {
            update_pergunta();
            if (alternativa_B.Text == respostaCorreta)
            {
                MessageBox.Show(" Resposta correta!");
            }
            else
            {
                MessageBox.Show($" Resposta errada! A correta era: {respostaCorreta}");
            }
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            update_pergunta();
            if (alternativa_C.Text == respostaCorreta)
            {
                MessageBox.Show(" Resposta correta!");
            }
            else
            {
                MessageBox.Show($" Resposta errada! A correta era: {respostaCorreta}");
            }
        }

        private void btn_D_Click(object sender, RoutedEventArgs e)
        {
            update_pergunta();
            if (alternativa_D.Text == respostaCorreta)
            {
                MessageBox.Show(" Resposta correta!");
            }
            else
            {
                MessageBox.Show($" Resposta errada! A correta era: {respostaCorreta}");
            }
        }
    }
}


