using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace QuizSenac
{
    /// <summary>
    /// Interação lógica para BemVindo.xam
    /// </summary>
    public partial class BemVindo : Page
    {
        public BemVindo()
        {
            InitializeComponent();

            // Ativar captura do Enter
            this.KeyDown += Window_KeyDown;
            this.Focusable = true;
            this.Loaded += (s, e) => this.Focus();


        }

        private void btn_iniciar_Click(object sender, RoutedEventArgs e)
        {
            // Abrir conexão com o banco quiz_jogador
            ConexaoDB.AbrirConexao("Server=localhost;Database=quiz_jogador;User Id=root;Password=root;");

            if (ConexaoDB.Conexao != null &&
                ConexaoDB.Conexao.State == System.Data.ConnectionState.Open)
            {
                NavigationService.Navigate(new Login());
            }
            else
            {
                MessageBox.Show(
                    "Não foi possível conectar ao banco de dados quiz_jogador.",
                    "Erro de Conexão",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Chama exatamente o clique do botão iniciar
                btn_iniciar_Click(btn_iniciar, new RoutedEventArgs(Button.ClickEvent));
            }

            if (e.Key == Key.Z)
            {
                ExecutarFuncao();

            }
            static void ExecutarFuncao()

            {
                ConexaoDB.AbrirConexao("Server=localhost;Database=quiz_jogador;User Id=root;Password=root;");

                if (ConexaoDB.Conexao != null &&
                   ConexaoDB.Conexao.State == System.Data.ConnectionState.Open)
                {

                    try
                    {
                        string sql = "TRUNCATE TABLE jogadores";
                        MySqlCommand cmd = new MySqlCommand(sql, ConexaoDB.Conexao);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        MessageBox.Show("Tabela pontuacao limpa com sucesso!");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao limpar a tabela pontuacao: " + ex.Message);
                    }

                }

                else
                {
                    MessageBox.Show("Conexão com o banco de dados não está aberta.");
                }
            }
        }
    }
}
