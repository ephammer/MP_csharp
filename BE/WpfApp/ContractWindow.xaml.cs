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
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        public static DataGrid ListContracts;

        public ContractWindow()
        {
            InitializeComponent();
            ListContracts = ListContract;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new AddContractWindow().Show();
            ListContract.ItemsSource = MainWindow.bl.ListContract;

        }

        private void ListEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListContracts_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = MainWindow.bl.ListContract;
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListContract.SelectedIndex != -1)
            {
                MainWindow.bl.RemoveContract((BE.Contract)ListContract.SelectedItem);
                ListContract.ItemsSource = MainWindow.bl.ListContract;
                ListContract.UpdateLayout();
                ListContract.Items.Refresh();
            }
            else
                MessageBox.Show("Please select item to delete");
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (ListContract.SelectedIndex != -1)
                new UpdateContractWindow(ListContract.SelectedIndex).Show();
            else
                MessageBox.Show("Please select contract to Update");
                
        }
    }
}
