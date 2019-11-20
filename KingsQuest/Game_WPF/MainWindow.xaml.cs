using Engine;
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

namespace Game_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUserInterface
    {
        public static KQEngine Engine { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Engine = new KQEngine(this);
            Engine.GameInit();

            DataContext = Engine;

        }

        public void ShowTalk(string dialogLine, Character whoIsTalking = null)
        {
            MessageBox.Show($"{whoIsTalking?.Name ?? "Someone"} says: {dialogLine}");
        }

        public void IndicateInventoryAddition(Item item)
        {
            MessageBox.Show("[" + item.Name + " was added to your inventory]");
        }

        public void CurrentRoomTransition(Room oldRoom, Room newRoom)
        {
            throw new NotImplementedException();
        }

        public void IndicateExit()
        {
            throw new NotImplementedException();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var king = Engine.CurrentRoom.Characters.FirstOrDefault(c => c is King);
            king.Talk();
            
        }
    }
}
