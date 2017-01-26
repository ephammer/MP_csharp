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
    /// Interaction logic for EmployerWindow.xaml
    /// </summary>
    public partial class EmployerWindow : Window
    {
        public static DataGrid ListEmployer;

        public EmployerWindow()
        {
            InitializeComponent();
            ListEmployer = ListEmployers;
        }
        
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployerWindow().Show();
        }

        private void ListEmployers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListEmployers_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            try
            {
                grid.ItemsSource = MainWindow.bl.ListEmployer;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListEmployers.SelectedIndex != -1)
            {
                MainWindow.bl.RemoveEmployer((BE.Employer)ListEmployers.SelectedItem);
                ListEmployers.ItemsSource = MainWindow.bl.ListEmployer;
                ListEmployers.UpdateLayout();
                ListEmployers.Items.Refresh();
            }
            else
                MessageBox.Show("Please select item to delete");
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListEmployers.SelectedIndex != -1)
                new UpdateEmployer(ListEmployers.SelectedIndex).Show();
            else
                MessageBox.Show("Please select employer to update");
        }
    }
}
