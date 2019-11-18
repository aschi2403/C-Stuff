using AuthenticationForm.Model;
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

namespace AuthenticationForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserDbContext context = new UserDbContext();
        public MainWindow()
        {
            InitializeComponent();

            this.userNameField.Text = context.Users.Find(1).Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userChecker = new UserChecker();
            var user = new User
            {
                Name = userNameField.Text,
                Password = passwordField.Text
            };

            var success = userChecker.Check(user);

            if (success)
                MessageBox.Show("Anmeldung erfolgreich");
            else
                MessageBox.Show("Benutzername oder Passwort falsch");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var userCreator = new UserCreator();

            var success = userCreator.Create(userNameField.Text, passwordField.Text);

            if (success)
                MessageBox.Show("User successfully added");
            else
                MessageBox.Show("Error adding user");
        }
    }
}
