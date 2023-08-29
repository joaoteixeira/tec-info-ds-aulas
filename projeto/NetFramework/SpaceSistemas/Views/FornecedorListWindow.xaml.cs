using SpaceSistemas.Models;
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
using System.Windows.Shapes;

namespace SpaceSistemas.Views
{
    /// <summary>
    /// Lógica interna para FornecedorListWindow.xaml
    /// </summary>
    public partial class FornecedorListWindow : Window
    {
        public FornecedorListWindow()
        {
            InitializeComponent();
            Loaded += FornecedorListWindow_Loaded;
        }

        private void FornecedorListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                var fornecedorDAO = new FornecedorDAO();
                dataGridFornecedores.ItemsSource = fornecedorDAO.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelecionado = dataGridFornecedores.SelectedItem as Fornecedor;

            var tela = new FornecedorFormWindow(fornecedorSelecionado.Id);
            tela.ShowDialog();
            CarregarDados();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Novo_Click(object sender, RoutedEventArgs e)
        {
            var window = new FornecedorFormWindow();
            window.ShowDialog();
        }
    }
}
