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
    /// Interação lógica para Final.xam
    /// </summary>
    public partial class Final : Page
    {
        public Final(int totalPontos)
        {
            InitializeComponent();
            lb_total.Content = totalPontos.ToString();
            AwaitPontosAsync();
        }

        private  async Task AwaitPontosAsync()
        {
            await Task.Delay(1000);  // Espera 2 segundos para mostrar o resultado
            gr_total.Visibility = Visibility.Hidden;
        }

        private void btn_Sair_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BemVindo());
        }
    }
}
