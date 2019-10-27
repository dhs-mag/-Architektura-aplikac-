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
using Data;
using Engine;
using Frontend.ViewModels;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly GameEngine GameEngine;

        private readonly MainWindowVm ViewModel;

        public MainWindow()
        {
            GameEngine = new GameEngine();
            GameEngine.GameInit();
            

            ViewModel = new MainWindowVm(GameEngine);
            DataContext = ViewModel;
            
            InitializeComponent();
        }

        private void RoomGoButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ListBox) e.Source).SelectedItem is Room selectedRoom)
            {
                GameEngine.MoveTo(selectedRoom);
                ViewModel.UpdateFromGameEngine(GameEngine);
            }

        }
    }
}
