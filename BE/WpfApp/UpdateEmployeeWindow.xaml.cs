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
    /// Interaction logic for UpdateEmployeeWindow.xaml
    /// </summary>
    public partial class UpdateEmployeeWindow : Window
    {
        public UpdateEmployeeWindow(int index)
        {
            InitializeComponent();
            this.degree.ItemsSource = Enum.GetValues(typeof(BE.Employee.Degree));

            BE.Employee employee = MainWindow.bl.ListEmployees[index];
            DataContext = employee;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.Text))
                    throw new Exception("Please enter valid id");
                if (string.IsNullOrWhiteSpace(FirstName.Text))
                    throw new Exception("Please enter valid First name");
                if (string.IsNullOrWhiteSpace(LastName.Text))
                    throw new Exception("Please enter valid Last name");
                if (string.IsNullOrWhiteSpace(phoneNumber.Text))
                    throw new Exception("Please enter valid phone number");
                if (string.IsNullOrWhiteSpace(adress.Text))
                    throw new Exception("Please enter valid adress");
                if (string.IsNullOrWhiteSpace(BankNumber.Text))
                    throw new Exception("Please enter valid bank number");
                if (string.IsNullOrWhiteSpace(Specialization.Text))
                    throw new Exception("Please enter valid specialization id");
                if (string.IsNullOrWhiteSpace(NameBank.Text))
                    throw new Exception("Please enter valid Bank name");
                if (string.IsNullOrWhiteSpace(BranchAdress.Text))
                    throw new Exception("Please enter valid branch adress");
                if (string.IsNullOrWhiteSpace(BranchCity.Text))
                    throw new Exception("Please enter valid Branch city");
                if (string.IsNullOrWhiteSpace(AccountNumber.Text))
                    throw new Exception("Please enter valid account number");
                if (degree.SelectedIndex == -1)
                    throw new Exception("Please choose a degree");
                if (Birthday.SelectedDate == null)
                    throw new Exception("Please enter valid bithday");
                if (string.IsNullOrWhiteSpace(BranchNumber.Text))
                    throw new Exception("Please enter valid Branch number");

                MainWindow.bl.UpdateEnployee(
                    new BE.Employee(
                        Convert.ToInt32(id.Text),
                        FirstName.Text,
                        LastName.Text,
                        Convert.ToDateTime(Birthday.SelectedDate),
                        Convert.ToInt32(phoneNumber.Text),
                        adress.Text,
                        (BE.Employee.Degree)degree.SelectedItem,
                        Convert.ToInt32(Specialization.Text),
                        Convert.ToBoolean(military.IsChecked),
                        new BE.BankAccount(
                            Convert.ToInt32(BankNumber.Text),
                            NameBank.Text,
                            Convert.ToInt32(BranchNumber.Text),
                            BranchAdress.Text,
                            BranchCity.Text,
                            Convert.ToInt32(AccountNumber.Text)
                            )
                        ));

                EmployeeWindow.ListEmployee.Items.Refresh();
                this.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
