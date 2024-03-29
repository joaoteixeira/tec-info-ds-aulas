﻿using System;
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
using SpaceSistemas.Helpers;

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

            LoadComboBox();

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

            if (comboBoxSexo.SelectedItem != null)
                _funcionario.Sexo = comboBoxSexo.SelectedItem as Sexo;

            _funcionario.Endereco = new Endereco();
            _funcionario.Endereco.Rua = txtRua.Text;
            _funcionario.Endereco.Bairro = txtBairro.Text;
            _funcionario.Endereco.Cidade = txtCidade.Text;

            if (int.TryParse(txtNumero.Text, out int numero))
                _funcionario.Endereco.Numero = numero;

            if (comboBoxEstado.SelectedItem != null)
                _funcionario.Endereco.Estado = comboBoxEstado.SelectedItem as string;

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

                if (_funcionario.Sexo != null)
                    comboBoxSexo.SelectedValue = _funcionario.Sexo.Id;

                if (_funcionario.Endereco != null)
                {
                    txtRua.Text = _funcionario.Endereco.Rua;
                    txtNumero.Text = _funcionario.Endereco.Numero.ToString();
                    txtBairro.Text = _funcionario.Endereco.Bairro;
                    txtCidade.Text = _funcionario.Endereco.Cidade;

                    comboBoxEstado.SelectedValue = _funcionario.Endereco.Estado;
                }

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

        private void LoadComboBox()
        {
            try
            {
                comboBoxEstado.ItemsSource = Estado.List();
                comboBoxSexo.ItemsSource = new SexoDAO().List();
            }
            catch (Exception ex)
            {

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


