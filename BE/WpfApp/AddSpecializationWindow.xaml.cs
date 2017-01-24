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
    /// Interaction logic for AddSpecializationWindow.xaml
    /// </summary>
    public partial class AddSpecializationWindow : Window
    {
        public AddSpecializationWindow()
        {
            InitializeComponent();
            this.field.ItemsSource = Enum.GetValues(typeof(BE.Specialization.NameField));
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name.Text))
                    throw new Exception("Please enter a valid name");
                if (string.IsNullOrWhiteSpace(SpecializationID.Text))
                    throw new Exception("Please enter a valid ID");
                if (string.IsNullOrWhiteSpace(MinHours.Text))
                    throw new Exception("Please enter a valid number of minimum hours");
                if (string.IsNullOrWhiteSpace(MaxHours.Text))
                    throw new Exception("Please enter a valid number of maximum hour");
                if (field.SelectedIndex == -1)
                    throw new Exception("Please select a field");

                MainWindow.bl.AddSpecialization(
                    new BE.Specialization(
                        Name.Text,
                        (BE.Specialization.NameField)field.SelectedItem,
                        Convert.ToInt32(SpecializationID.Text),
                        Convert.ToInt32(MinHours.Text),
                        Convert.ToInt32(MaxHours.Text)
                    ));
                SpecializationWindow.ListSpecializations.Items.Refresh();
                this.Close();

            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
    }
}
