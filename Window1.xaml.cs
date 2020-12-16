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

namespace WPF_MVVM_metanit.com
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ApplicationViewModel applicationView;
        public Window1()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            applicationView = ApplicationViewModel.getInstance();
        }
        

        private void butt_Click(object sender, RoutedEventArgs e)
        {
            Phone phone = new Phone();
            applicationView.Phones.Insert(0, phone);
            Close();
        }
    }
}
