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
using SpaceSistemas.Models;

namespace SpaceSistemas.Views
{
    /// <summary>
    /// Lógica interna para FuncionarioListWindow.xaml
    /// </summary>
    public partial class FuncionarioListWindow : Window
    {
        public FuncionarioListWindow()
        {
            InitializeComponent();
            Loaded += FuncionarioListWindow_Loaded;
        }

        private void FuncionarioListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new FuncionarioDAO();

                dataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Novo_Click(object sender, RoutedEventArgs e)
        {
            var window = new FuncionarioFormWindow();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelected = dataGrid.SelectedItem as Funcionario;

            var window = new FuncionarioFormWindow(funcionarioSelected.Id);
            window.ShowDialog();
            LoadDataGrid();
        }
    }
}
