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
        private List<string> perguntasUsadas = new List<string>();
        private string respostaCorreta;
        private DispatcherTimer cronometro = new DispatcherTimer();
        private int tempoRestante;  // Variável de instância para o tempo restante
        private int _perguntaNum = 1;
        private int _totalPontos;

        public Pergunta1()
        {
            InitializeComponent();
            gr_resultado.Visibility = Visibility.Hidden; // Esconde o grid de resultado inicialmente


            // Adicionar o manipulador de evento Tick apenas uma vez
            cronometro.Tick += Cronometro_Tick;
            cronometro.Interval = TimeSpan.FromSeconds(1);  // Intervalo de 1 segundo
            update_pergunta();  // Inicia a primeira pergunta
        }

        private void update_pergunta()
        {
            lab_per1.Content = $" Pergunta {_perguntaNum++}";

            // Consulta para obter a pergunta
            Random rand = new Random();
            var idx = rand.Next(1, 20);
            string sql = $"select * from perguntas where PerguntasID = {idx}";
            MySqlCommand cmd = new MySqlCommand(sql, ConexaoDB.Conexao);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (perguntasUsadas.Contains(reader["PerguntasID"].ToString()))
                {
                    reader.Close();
                    update_pergunta();  // Chama recursivamente para obter uma nova pergunta
                }
                else
                {
                    perguntasUsadas.Add(reader["PerguntasID"].ToString());
                }

                respostaCorreta = reader["respostaCorreta"].ToString();
                txt_pergunta.Text = reader["Pergunta"].ToString();
                alternativa_A.Text = reader["opA"].ToString();
                alternativa_B.Text = reader["opB"].ToString();
                alternativa_C.Text = reader["opC"].ToString();
                alternativa_D.Text = reader["opD"].ToString();
            }
            reader.Close();

            updateTime();  // Atualiza o tempo para a nova pergunta
        }
        private void updateTime()
        {
            cronometro.Stop();  // Para o cronômetro
            tempoRestante = 30;  // Reseta o tempo para 5 segundos
            lb_Tempo.Content = $"{tempoRestante}s";  // Atualiza o label imediatamente
            cronometro.Start();  // Inicia o cronômetro
        }

        private void Cronometro_Tick(object sender, EventArgs e)
        {
            tempoRestante--;  // Decrementa o tempo
            lb_Tempo.Content = $"{tempoRestante}s";  // Atualiza o label

            if (tempoRestante <= 0)
            {
                cronometro.Stop();  // Para o cronômetro quando o tempo acaba
                update_pergunta();  // Vai para a próxima pergunta
            }
        }

        private void btn_A_Click(object sender, RoutedEventArgs e)
        {
            VerificarResultado(t1.Text);
        }

        private void btn_B_Click(object sender, RoutedEventArgs e)
        {
            VerificarResultado(t2.Text);
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            VerificarResultado(t3.Text);
        }

        private void btn_D_Click(object sender, RoutedEventArgs e)
        {
            VerificarResultado(t4.Text);
        }

        private async Task VerificarResultado(string escolha)
        {
            gr_resultado.Visibility = Visibility.Visible;

            if (escolha == respostaCorreta)
            {
                //MessageBox.Show("Resposta correta!");
                if (tempoRestante >= 15)
                {
                    lb_resultado.Content = ("+10");
                    _totalPontos += 10;
                }
                else if (tempoRestante >= 1)
                {
                    lb_resultado.Content = ("+5");
                    _totalPontos += 5;
                }
                else
                {
                    lb_resultado.Content = ("0");
                }
            }
            else
            {
                //MessageBox.Show($"Resposta errada! A correta era: {respostaCorreta}");
                lb_resultado.Content = ("0");
            }

            await Task.Delay(1000);  // Espera 2 segundos para mostrar o resultado
            gr_resultado.Visibility = Visibility.Hidden;  // Esconde o grid de resultado
            if (perguntasUsadas.Count >= 5)
            {
                // Navega para a página de resultados após 5 perguntas
                NavigationService.Navigate(new Final());
                var teste = _totalPontos;
            }
            else
            {
                update_pergunta();  // Atualiza para a próxima pergunta
            }
        }
    }
}


