using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfAppExemplo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pessoa pessoa;

        private List<string> estados;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            pessoa = new Pessoa();
            estados = new List<string>();

            estados.Add("Acre");
            estados.Add("Amapá");
            estados.Add("Rondônia");
            estados.Add("Mato Grosso");

            cmbEstado.ItemsSource = estados;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            string nome, data_nasc, cpf, email, telefone;

            pessoa.Nome = txtNome.Text;
            data_nasc = txtDataNasc.Text;
            cpf = txtCPF.Text;
            email = txtEmail.Text;
            telefone = txtTelefone.Text;


            string filhos = pessoa.TemFilhos ? "Sim" : "Não";


            MessageBox.Show($"Nome: {pessoa.Nome}\n" +
                $"Data de Nascimento: {data_nasc}\n" +
                $"CPF: {cpf}\n" +
                $"E-mail: {email}\n" +
                $"Whatsapp: {telefone}\n" +
                $"Sexo: {pessoa.Sexo}\n" +
                $"Filhos? {filhos}\n" +
                $"Estado: {pessoa.Estado}", "Informações", MessageBoxButton.OK, MessageBoxImage.Information);

            ClearTextBox();
        }

        private void ClearTextBox()
        {
            txtNome.Text = "";
            txtDataNasc.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
        }

        private void mnuSair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente sair da aplicação?", "App - Cadastro de pessoas", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                this.Close();
        }

        private void mnuVersao_Click(object sender, RoutedEventArgs e)
        {
            VersionDialog vsDialog = new VersionDialog();
            vsDialog.ShowDialog();
        }

        private void RBSexo_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);

            pessoa.Sexo = rb.Content.ToString();
        }

        private void CBFilhos_Checked(object sender, RoutedEventArgs e)
        {
            if (cbFilhos.IsChecked == true)
                pessoa.TemFilhos = true;
            else
                pessoa.TemFilhos = false;
        }

        private void txtEmail_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            string email = txtEmail.Text.Trim();

            if (!Util.IsEmail(email))
            {
                e.Handled = true;
                txtEmail_Error.Visibility = Visibility.Visible;
                txtEmail.Focus();
            }
            else
                txtEmail_Error.Visibility = Visibility.Collapsed;

        }

        private void txtCPF_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            string cpf = txtCPF.Text.Trim();

            if (!Util.IsCPF(cpf))
            {
                e.Handled = true;
                txtCPF_Error.Visibility = Visibility.Visible;
                txtCPF.Focus();
            }
            else
                txtCPF_Error.Visibility = Visibility.Collapsed;

        }

        private void cmbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            pessoa.Estado = cmbEstado.SelectedItem.ToString();

            //MessageBox.Show("Estado selecionado: " + item);
        }
    }
}
