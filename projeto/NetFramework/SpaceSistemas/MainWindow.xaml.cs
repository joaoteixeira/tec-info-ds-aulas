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
using SpaceSistemas.Dominio.Venda;

namespace SpaceSistemas
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtDataAtual.Text = "-";
            // DateTime.Now.ToString("dd/MM/yyyy");

            List<Venda> listaVendas = new List<Venda>();


            for (int i = 0; i < 30; i++)
            {
                listaVendas.Add(new Venda()
                {
                    Id = i + 1,
                    Cliente = "João - " + i,
                    QuantidadeProdutos = 5 * i,
                    ValorTotal = 120.55 * i,
                    Situacao = "Aberta"
                });
            }
        }

        private void Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            MessageBox.Show("Menu button click");
        }
    }
}
