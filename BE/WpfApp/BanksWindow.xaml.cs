﻿using System;
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
    /// Interaction logic for BanksWindow.xaml
    /// </summary>
    public partial class BanksWindow : Window
    {
        public BanksWindow()
        {
            InitializeComponent();
            try
            {
                banks.ItemsSource = MainWindow.bl.ListBankBranches;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void banks_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }
    }
}
