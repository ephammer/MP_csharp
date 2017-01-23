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
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public static DataGrid ListEmployee;

        public EmployeeWindow()
        {
            InitializeComponent();
            ListEmployee = ListEmployees;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployeeWindow().Show();
        }

        private void ListEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = MainWindow.bl.ListEmployees;
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListEmployees.SelectedIndex != -1)
            {
                MainWindow.bl.RemoverEmployee((BE.Employee)ListEmployees.SelectedItem);
                ListEmployees.UpdateLayout();
            }
            else
                MessageBox.Show("Please select item to delete");
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            //new UpdateEmployee(ListEmployees.SelectedIndex).Show();
        }
    }
}
