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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EmployerWindow : Window
    {
        public EmployerWindow()
        {
            InitializeComponent();
        }
        
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployerWindow().Show();
        }
    }
}