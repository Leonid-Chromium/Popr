using System;
using System.Collections.Generic;
using System.Data;
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

namespace popr.UCs
{
    /// <summary>
    /// Логика взаимодействия для TestDG.xaml
    /// </summary>
    public partial class TestDG : UserControl
    {
        public TestDG()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable sqlDataTable = Class.SQLClass.returnDT("SELECT * FROM Agent");
            dataTable.ItemsSource = sqlDataTable.DefaultView;
        }
    }
}
