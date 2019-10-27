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
using WPF_basics.ViewModels;

namespace WPF_basics.Windows
{
    /// <summary>
    /// Interaction logic for ViewModelBinding.xaml
    /// </summary>
    public partial class ViewModelBinding : Window
    {
        public ViewModelBinding()
        {
            InitializeComponent();

            MyViewModel MyWM = new MyViewModel();
            DataContext = MyWM;
        }
    }
}
