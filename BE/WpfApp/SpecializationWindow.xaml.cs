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
    /// Interaction logic for SpecializationWindow.xaml
    /// </summary>
    public partial class SpecializationWindow : Window
    {
        public static DataGrid ListSpecializations;

        public SpecializationWindow()
        {
            InitializeComponent();
            ListSpecializations = ListSpecialization;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new AddSpecializationWindow().Show();
        }

        private void ListSpecialization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListSpecialization_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = MainWindow.bl.ListSpecialzation;
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListSpecialization.SelectedIndex != -1)
            {
                MainWindow.bl.RemoveSpecialization((BE.Specialization)ListSpecialization.SelectedItem);
                ListSpecialization.ItemsSource = MainWindow.bl.ListSpecialzation;
                ListSpecialization.UpdateLayout();
                ListSpecialization.Items.Refresh();
            }
            else
                MessageBox.Show("Please select item to delete");
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListSpecialization.SelectedIndex != -1)
                new UpdateSpecializationWindow(ListSpecialization.SelectedIndex).Show();
            else
                MessageBox.Show("Please select specialization to Update");
        }
    }
}
