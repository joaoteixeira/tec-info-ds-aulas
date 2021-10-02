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
    /// Lógica interna para FuncionarioFormWindow.xaml
    /// </summary>
    public partial class FuncionarioFormWindow : Window
    {
        public FuncionarioFormWindow()
        {
            InitializeComponent();
            Loaded += FuncionarioFormWindow_Loaded;
        }

        private void FuncionarioFormWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Nome = txtNome.Text;
                funcionario.CPF = txtCPF.Text;
                funcionario.RG = txtRG.Text;
                funcionario.DataNascimento = (DateTime)dtPickerDataNascimento.SelectedDate;
                funcionario.Email = txtEmail.Text;
                funcionario.Celular = txtCelular.Text;
                funcionario.Funcao = txtFuncao.Text;
                funcionario.Salario = Convert.ToDouble(txtSalario.Text);

                FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                funcionarioDAO.Insert(funcionario);

                MessageBox.Show("O Funcionário foi adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja continuar adicionando funcionários?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputs()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            dtPickerDataNascimento.SelectedDate = null;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtFuncao.Text = "";
            txtSalario.Text = "";
        }
    }
}


