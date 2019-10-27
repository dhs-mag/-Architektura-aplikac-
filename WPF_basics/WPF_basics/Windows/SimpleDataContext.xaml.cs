using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPF_basics.Models;

namespace WPF_basics.Windows
{
    /// <summary>
    /// Interaction logic for SimpleDataContext.xaml
    /// </summary>
    public partial class SimpleDataContext : Window
    {
        public ObservableCollection<User> Users { get; set; }
        
        public User BoundSelectedItem { get; set; }

        public SimpleDataContext()
        {
            InitializeComponent();

            Users = new ObservableCollection<User>();

            Users.Add(new User() { Name = "Franta Lala", Age = 30 });
            Users.Add(new User() { Name = "John Doe", Age = 82 });
            Users.Add(new User() { Name = "Milos Big", Age = 37 });

            DataContext = this;

            // Can be set in XAML (and should be if static)!
            //lbUsers.ItemsSource = Users;
        }

        #region Buttons event handlers

        // For simplicity these methods manipulate directly with collection of Users, but they should actually call model with this functions (for example Class Users).

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Users.Add(new User() { Name = "New user" });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (BoundSelectedItem != null)
            {
                User u = BoundSelectedItem;
                u.Name = u.Name + " Changed";
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (BoundSelectedItem != null)
                Users.Remove(BoundSelectedItem);
        }

        #endregion
    }
}
