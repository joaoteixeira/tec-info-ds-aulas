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

namespace WpfAppExemplo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            string nome, data_nasc, cpf, email, telefone;

            nome = txtNome.Text;
            data_nasc = txtDataNasc.Text;
            cpf = txtCPF.Text;
            email = txtEmail.Text;
            telefone = txtTelefone.Text;


            MessageBox.Show($"Nome: {nome}\n" +
                $"Data de Nascimento: {data_nasc}\n" +
                $"CPF: {cpf}\n" +
                $"E-mail: {email}\n" +
                $"Whatsapp: {telefone}");
        }
    }
}
