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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AddEmployerWindow.xaml
    /// </summary>
    public partial class AddEmployerWindow : Window
    {
        public AddEmployerWindow()
        {
            InitializeComponent();
            this.fields.ItemsSource =Enum.GetValues(typeof(BE.Employer.NameField));
        }

        private void compagny_Checked(object sender, RoutedEventArgs e)
        {
                CompagnyNameLabel.Visibility = Visibility.Visible;
        }

        private void compagny_Unchecked(object sender, RoutedEventArgs e)
        {
            CompagnyNameLabel.Visibility = Visibility.Collapsed;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(id.Text))
                    throw new Exception("Problem with the id, please correct the id field");
                if (string.IsNullOrWhiteSpace(firstName.Text))
                    throw new Exception("Problem with the First Name, please enter valid first name");
                if (Convert.ToBoolean(compagny.IsChecked))
                {
                    if (string.IsNullOrWhiteSpace(compagnyName.Text))
                        throw new Exception("Please enter a valid compagny name");
                }
                else
                    compagnyName.Text = null;
                if (string.IsNullOrWhiteSpace(phoneNumber.Text))
                    throw new Exception("Please enter a valid phone number");
                if (string.IsNullOrWhiteSpace(adress.Text))
                    throw new Exception("Please enter a valid adress");
                if (fields.SelectedIndex == -1)
                    throw new Exception("Please choose a field");

                MainWindow.bl.AddEmployer(
                    new BE.Employer(
                        Convert.ToInt32(id.Text),
                        Convert.ToBoolean(compagny.IsChecked),
                        firstName.Text,
                        compagnyName.Text,
                        Convert.ToInt32(phoneNumber.Text),
                        adress.Text,
                        (BE.Employer.NameField)fields.SelectedItem,
                        DateTime.Now));

                /* 
                 * If everything is correctly entered than show 
                 * the full list of Employer
                 * Finally close the addEmployerWindow
                 * */

                MessageBox.Show(MainWindow.bl.printListEmployer());
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
