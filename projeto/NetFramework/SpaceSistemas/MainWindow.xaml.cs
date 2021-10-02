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
using SpaceSistemas.Models;


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
            //DateTime.Now.ToString("dd/MM/yyyy");

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

            //MessageBox.Show("Menu button click");
            Insert_Teste();
        }

        private void Insert_Teste()
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Nome = "Ana da Silva";
                funcionario.CPF = "213.123.232-32";
                funcionario.RG = "2123213 SESDEC/RO";
                funcionario.DataNascimento = DateTime.Now;
                funcionario.Email = "anasilva@gmail.com";
                funcionario.Celular = "(69) 9 8421-0101";
                funcionario.Funcao = "Vendedora";
                funcionario.Salario = 2550.0;

                FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                funcionarioDAO.Insert(funcionario);

                MessageBox.Show("O Funcionário foi adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
