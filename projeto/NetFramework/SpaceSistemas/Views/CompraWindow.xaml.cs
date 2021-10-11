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
    /// Lógica interna para Compra.xaml
    /// </summary>
    public partial class CompraWindow : Window
    {
        private Compra _compra = new Compra();

        private List<CompraItem> _compraItensList = new List<CompraItem>();

        public CompraWindow()
        {
            InitializeComponent();
            Loaded += CompraWindow_Loaded;
        }

        private void CompraWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (dtPickerData.SelectedDate != null)
                _compra.Data = (DateTime)dtPickerData.SelectedDate;

            if (comboBoxFuncionario.SelectedItem != null)
                _compra.Funcionario = comboBoxFuncionario.SelectedItem as Funcionario;

            if (comboBoxFornecedor.SelectedItem != null)
                _compra.Fornecedor = comboBoxFornecedor.SelectedItem as Fornecedor;

            _compra.FormaPagamento = txtFormaPagamento.Text;
            _compra.ValorTotal = UpdateValorTotal();
            _compra.Itens = _compraItensList;

            SalvarCompra();
        }

        private void BtnAddProduto_Click(object sender, RoutedEventArgs e)
        {
            var window = new CompraProdutoListAdd();
            window.ShowDialog();

            var produtosSelecionadosList = window.ProdutosSelecionados;
            var count = 1;

            foreach(Produto produto in produtosSelecionadosList)
            {

                if (!_compraItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _compraItensList.Add(new CompraItem()
                    {
                        Id = count,
                        Produto = produto,
                        Quantidade = 1,
                        Valor = produto.ValorCompra,
                        ValorTotal = produto.ValorCompra
                    });

                    count++;
                }
            }

            LoadDataGrid();
        }

        private void BtnRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGrid.SelectedItem as CompraItem;
            _compraItensList.Remove(itemSelected);
            LoadDataGrid();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as CompraItem;

            var value = (e.EditingElement as TextBox).Text;
            _ = int.TryParse(value, out int quantidade);

            if (quantidade > 1)
            {
                item.Quantidade = quantidade;
                item.ValorTotal = quantidade * item.Valor;
            }

            LoadDataGrid();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SalvarCompra()
        {
            try
            {
                if (Validate())
                {
                    var dao = new CompraDAO();
                    dao.Insert(_compra);

                    MessageBox.Show($"Compra realizada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _compraItensList.ForEach(item => valor += item.ValorTotal);

            txtValorTotal.Text = valor.ToString("C");

            return valor;
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = _compraItensList;
        }

        private void LoadData()
        {
            dtPickerData.SelectedDate = DateTime.Now;

            try
            {
                comboBoxFuncionario.ItemsSource = new FuncionarioDAO().List();
                comboBoxFornecedor.ItemsSource = new FornecedorDAO().List();

                comboBoxFuncionario.SelectedValue = Usuario.GetFuncionarioId();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Validate()
        {
            var validator =  new CompraValidator();
            var result = validator.Validate(_compra);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
        }

    }
}
