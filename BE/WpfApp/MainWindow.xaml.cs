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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static BL.IBL bl;

        public MainWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }
        
        private void Employer_Button_Click(object sender, RoutedEventArgs e)
        {
            new EmployerWindow().Show();
        }

        private void Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            if (bl.ListSpecialzation.Count!=0)
                new EmployeeWindow().Show();
            else
                MessageBox.Show("Please create specialization first");

        }

        private void Contract_Button_Click(object sender, RoutedEventArgs e)
        {
            new ContractWindow().Show();
        }

        private void Specialization_Button_Click(object sender, RoutedEventArgs e)
        {
            new SpecializationWindow().Show();
        }
    }
}
