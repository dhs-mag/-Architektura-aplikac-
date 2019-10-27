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

namespace WPF_basics.Windows
{
    /// <summary>
    /// Interaction logic for ElementBinding.xaml
    /// </summary>
    public partial class ElementBinding : Window
    {
        public ElementBinding()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Close_Command(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Close_Command_CanEx(object sender, CanExecuteRoutedEventArgs e)
        {
            // Always active.
            e.CanExecute = true;
        }
    }
}
