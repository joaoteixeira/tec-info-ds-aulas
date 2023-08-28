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
using SpaceSistemas.Views;

namespace SpaceSistemas
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            //_ = txtUsuario.Focus();
            //new FuncionarioListWindow().Show();
            //this.Close();
        }

        private void BtnAcessar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = "joao"; // txtUsuario.Text;
            string senha = "123456"; // passBoxSenha.Password.ToString();

            if (Usuario.Login(usuario, senha))
            {
                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização negada", MessageBoxButton.OK, MessageBoxImage.Warning);
                _ = txtUsuario.Focus();
            }

        }
    }
}
