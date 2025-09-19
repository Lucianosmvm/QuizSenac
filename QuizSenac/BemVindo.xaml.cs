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
    /// Interação lógica para BemVindo.xam
    /// </summary>
    public partial class BemVindo : Page
    {
        public BemVindo()
        {
            InitializeComponent();
        }

        private void btn_iniciar_Click(object sender, RoutedEventArgs e)
        {
            ConexaoDB.AbrirConexao();

            if (ConexaoDB.Conexao != null && ConexaoDB.Conexao.State == System.Data.ConnectionState.Open)
                NavigationService.Navigate(new Login());
        }
    }
}
