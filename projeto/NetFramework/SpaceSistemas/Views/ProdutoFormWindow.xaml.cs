using SpaceSistemas.Models;
using System;
using System.Windows;

namespace SpaceSistemas.Views
{
    /// <summary>
    /// Lógica interna para ProdutoFormWindow.xaml
    /// </summary>
    public partial class ProdutoFormWindow : Window
    {
        public ProdutoFormWindow()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var produto = new Produto();
                produto.Nome = txtNome.Text;
                produto.Unidade = txtUnidade.Text;
                produto.ValorVenda = double.Parse(txtValor.Text);

                var produtoDAO = new ProdutoDAO();
                var resultado = produtoDAO.Insert(produto);

                MessageBox.Show(resultado);
                

                if (resultado == "Os campos obrigatórios devem ser preenchidos")
                {
                    MessageBox.Show("Erro");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
