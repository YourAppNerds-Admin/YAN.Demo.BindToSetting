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
using YAN.Demo.BindToSetting.ViewModel;

namespace YAN.Demo.BindToSetting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddToStringCollectionSetting_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).StringCollectionSetting.Add(DateTime.Now.ToString());
        }

        private void AddToStringCollectionToObjectSetting_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).StringCollectionToObjectSetting.Add(new ListviewCheckboxItem(DateTime.Now.ToString(), true));
        }
    }
}
