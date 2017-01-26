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
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        public AddContractWindow()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ContractID.Text))
                    throw new Exception("Please enter valid contract ID");
                if (string.IsNullOrWhiteSpace(EmployeeID.Text))
                    throw new Exception("Please enter valid employee ID");
                if (string.IsNullOrWhiteSpace(EmployerID.Text))
                    throw new Exception("Please enter valid employer ID");
                if (string.IsNullOrWhiteSpace(hourlyWageBrute.Text))
                    throw new Exception("Please enter valid number of hourly wage brute");
                if (string.IsNullOrWhiteSpace(hourlyWageNet.Text))
                    throw new Exception("Please enter valid number of hourly wage net");
                if (StartContract.SelectedDate==null)
                    throw new Exception("Please enter a date of the begigning of contract");
                if (EndContract.SelectedDate == null)
                    throw new Exception("Please enter a date of the end of contract");

                MainWindow.bl.AddContract(
                    new BE.Contract(
                        Convert.ToInt32(ContractID.Text),
                        Convert.ToInt32(EmployerID.Text),
                        Convert.ToInt32(EmployeeID.Text),
                        Convert.ToBoolean(Interview.IsChecked),
                        Convert.ToBoolean(Signature.IsChecked),
                        Convert.ToInt32(hourlyWageBrute.Text),
                        Convert.ToInt32(hourlyWageNet.Text),
                        Convert.ToDateTime(StartContract.SelectedDate),
                        Convert.ToDateTime(EndContract.SelectedDate)
                    ));
                ContractWindow.ListContracts.ItemsSource = MainWindow.bl.ListContract;
                ContractWindow.ListContracts.Items.Refresh();
                this.Close();

            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
