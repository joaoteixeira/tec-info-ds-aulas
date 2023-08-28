using SpaceSistemas.Helpers;
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
    /// Lógica interna para FornecedorFormWindow.xaml
    /// </summary>
    public partial class FornecedorFormWindow : Window
    {
        private Fornecedor _fornecedor = new Fornecedor();
  
        public FornecedorFormWindow()
        {
            InitializeComponent();
            Loaded += FornecedorFormWindow_Loaded;
        }

        private void FornecedorFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                comboBoxEstado.ItemsSource = Estado.List();
            }
            catch {}
        }

        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
            _fornecedor.RazaoSocial = txtRazaoSocial.Text;
            _fornecedor.NomeFantasia = txtNomeFantasia.Text;
            _fornecedor.CNPJ= txtCNPJ.Text;
            _fornecedor.Telefone = txtTelefone.Text;
            _fornecedor.Representante = txtRepresentante.Text;
            
            // Validação Verificar campos em branco

            try
            {
                var fornecedorDAO = new FornecedorDAO();
                fornecedorDAO.Insert(_fornecedor);

                MessageBox.Show($"Fornecedor `{_fornecedor.RazaoSocial}` adicionado com sucesso!");

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
