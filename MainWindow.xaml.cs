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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MVVM_metanit.com
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int idx;
        ApplicationViewModel applicationView;
        public MainWindow()
        {
            InitializeComponent();
            applicationView = ApplicationViewModel.getInstance();
            DataContext = new ApplicationViewModel(); // Это обязательно должно быть
        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = applicationView.Phones;
        }
    }
}
