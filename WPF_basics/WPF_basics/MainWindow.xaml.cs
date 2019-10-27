using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF_basics.Windows;

namespace WPF_basics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ElementBinding EB_window;
        SimpleDataContext SDC_window;
        ViewModelBinding VMB_window;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Buttons event handlers

        private void ElementBindidng_Click(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<ElementBinding>())
            {
                MessageBox.Show("This window is already open!", "Error", MessageBoxButton.OK);
            }
            else
            {
                EB_window = new ElementBinding();
                EB_window.Show();
            }
        }

        private void SimpleDataContext_Click(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<SimpleDataContext>())
            {
                MessageBox.Show("This window is already open!", "Error", MessageBoxButton.OK);
            }
            else
            {
                SDC_window = new Windows.SimpleDataContext();
                SDC_window.Show();
            }
        }

        private void ViewModelBinding_Click(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<ViewModelBinding>())
            {
                MessageBox.Show("This window is already open!", "Error", MessageBoxButton.OK);
            }
            else
            {
                VMB_window = new Windows.ViewModelBinding();
                VMB_window.Show();
            }
        }


        #endregion

        /// <summary>
        /// Test if window of specific class is active.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        /// <summary>
        /// Close all child windows if open.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (EB_window != null)
                if (EB_window.IsLoaded)
                    EB_window.Close();

            base.OnClosing(e);
        }
    }
}
