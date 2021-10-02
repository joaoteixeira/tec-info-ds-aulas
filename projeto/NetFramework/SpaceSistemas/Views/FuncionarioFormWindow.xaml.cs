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
        private int _id;

        private Funcionario _funcionario;

        public FuncionarioFormWindow()
        {
            InitializeComponent();
            Loaded += FuncionarioFormWindow_Loaded;
        }

        public FuncionarioFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += FuncionarioFormWindow_Loaded;
        }

        private void FuncionarioFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _funcionario = new Funcionario();

            if (_id > 0)
                FillForm();          
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _funcionario.Nome = txtNome.Text;
            _funcionario.CPF = txtCPF.Text;
            _funcionario.RG = txtRG.Text;
            _funcionario.Email = txtEmail.Text;
            _funcionario.Celular = txtCelular.Text;
            _funcionario.Funcao = txtFuncao.Text;

            if (double.TryParse(txtSalario.Text, out double salario))
                _funcionario.Salario = salario;

            if (dtPickerDataNascimento.SelectedDate != null)
                _funcionario.DataNascimento = (DateTime)dtPickerDataNascimento.SelectedDate;

            SaveData();
        }

        private bool Validate()
        {
            var validator = new FuncionarioValitador();
            var result = validator.Validate(_funcionario);
            
            if(!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach(var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
        }

        private void SaveData()
        {
            try
            {
                if (Validate())
                {
                    var dao = new FuncionarioDAO();
                    var text = "atualizado";

                    if (_funcionario.Id == 0)
                    {
                        dao.Insert(_funcionario);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_funcionario);

                    MessageBox.Show($"O Funcionário foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillForm()
        {
            try
            {
                var dao = new FuncionarioDAO();
                _funcionario = dao.GetById(_id);

                txtId.Text = _funcionario.Id.ToString();
                txtNome.Text = _funcionario.Nome;
                txtCPF.Text = _funcionario.CPF;
                txtRG.Text = _funcionario.RG;
                dtPickerDataNascimento.SelectedDate = _funcionario.DataNascimento;
                txtEmail.Text = _funcionario.Email;
                txtCelular.Text = _funcionario.Celular;
                txtFuncao.Text = _funcionario.Funcao;
                txtSalario.Text = _funcionario.Salario.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_funcionario.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando funcionários?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            else
                this.Close();
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


