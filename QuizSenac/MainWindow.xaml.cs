using System.Windows;
using System.Windows.Navigation;

namespace QuizSenac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ConexaoDB.FecharConexao();
        }
    }
}