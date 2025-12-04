using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Notice;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace QuizSenac
{
    public partial class Pergunta1 : Page
    {
        private List<string> perguntasUsadas = new List<string>();
        private string respostaCorreta;
        private DispatcherTimer cronometro = new DispatcherTimer();
        private int tempoRestante;  // Variável de instância para o tempo restante
        private int _perguntaNum = 1;
        private int _totalPontos;
        private string NomeJogador;

        private Login login;

        public Pergunta1(string nomeJogador)
        {
            InitializeComponent();

            NomeJogador = nomeJogador;
            gr_resultado.Visibility = Visibility.Hidden;

            cronometro.Tick += Cronometro_Tick;
            cronometro.Interval = TimeSpan.FromSeconds(1);
            update_pergunta();
        }

        private void update_pergunta()
        {
            if (((App)Application.Current).isFinished)
            {
                return;
            }

            Random rand = new Random();
            var idx = rand.Next(1, 39);
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
                    lab_per1.Content = $" Pergunta {_perguntaNum++}";
                    perguntasUsadas.Add(reader["PerguntasID"].ToString());
                }

                respostaCorreta = reader["respostaCorreta"].ToString().Replace(" ", "");
                txt_pergunta.Text = reader["Pergunta"].ToString();
                alternativa_A.Text = reader["opA"].ToString();
                alternativa_B.Text = reader["opB"].ToString();
                alternativa_C.Text = reader["opC"].ToString();
                alternativa_D.Text = reader["opD"].ToString();
            }
            else
            {
                reader.Close();
                update_pergunta();
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

                int tempoMax = 30;
                int tempoGasto = 12;
                int pontuacaoMax = 100;

                int pontuacao = (int)(pontuacaoMax * Math.Exp(-3 * (tempoGasto / (double)tempoMax)));

                _totalPontos += pontuacao;

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
                // MessageBox.Show($"Resposta errada! A correta era: {respostaCorreta}");
                lb_resultado.Content = ("0");
            }

            await Task.Delay(1000);  // Espera 2 segundos para mostrar o resultado
            gr_resultado.Visibility = Visibility.Hidden;  // Esconde o grid de resultado

            if (perguntasUsadas.Count >= 10)// Navega para a página de resultados após 10 perguntas
            {
                InsertPontos(NomeJogador, _totalPontos);

                NavigationService.Navigate(new Final(_totalPontos));
            }
            else
            {
                update_pergunta();  // Atualiza para a próxima pergunta
            }
        }

        private void InsertPontos(string nome, double pontos)
        {
            try
            {
                string sql = "INSERT INTO Jogadores (Nome, Pontos) VALUES (@nome, @pontos)";
                using (var cmdPontos = new MySqlCommand(sql, ConexaoDB.Conexao))
                {
                    cmdPontos.Parameters.AddWithValue("@nome", nome);
                    cmdPontos.Parameters.AddWithValue("@pontos", pontos);
                    cmdPontos.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
            }
        }
    }
}


