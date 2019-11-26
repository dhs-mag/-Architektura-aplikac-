using Data;
using Engine;
using Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
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

namespace WpfInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUserInterface
    {

        public KQEngine Engine { get; set; }

        public ObservableCollection<Item> Inventory { get; private set; }
        public ObservableCollection<Character> Characters { get; private set; }
        public string Decription { get; private set; }

        public ResourceManager Lang { get => Resource1.ResourceManager; }

        public MainWindow()
        {
            InitializeComponent();

            Inventory = new ObservableCollection<Item>();
            Characters = new ObservableCollection<Character>();
            this.TextBlock_character_name.Text = "";
            this.TextBlock_character_description.Text = "";


            Engine = new KQEngine(this);
            Engine.GameInit();
            Engine.PrintState();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Engine.Command_TALK(Engine.CurrentRoom.Characters.Where(charakter => charakter.Name == "King").First());
            Engine.PrintState();
        }

        public void ShowTalk(Character sender, string key)
        {
            this.TextBlock_character_name.Text = sender.Name+":";
            this.TextBlock_character_description.Text = this.Lang.GetString(key);
        }

        public void ItemAdd(Item item)
        {
            //throw new NotImplementedException();
        }

        public void PrintState(KQEngine engine)
        {
            //TODO homework implement print state
            //Console.WriteLine($"|>{this.Lang.GetString("StateAroundYou")}:");
            //Console.WriteLine($"|>{this.Lang.GetString("StateSeeInside")}:");
            //Console.WriteLine($"|>{this.Lang.GetString("StateYouHave")}:");

            this.TextBlock_room_name.Text = "Room "+engine.CurrentRoom.Name;
            this.TextBlock_room_decription.Text = engine.CurrentRoom.Description;

            Inventory.Clear();
            foreach (var item in engine.Inventory)
            {
                Inventory.Add(item);
            }

            Characters.Clear();
            foreach (var character in engine.CurrentRoom.Characters)
            {
                Characters.Add(character);
            }
        }

        private void CharacterButtonClick(object sender, RoutedEventArgs e)
        {

            Button cmd = (Button)sender;
            if (cmd.DataContext is Character)
            {

                Character character = (Character)cmd.DataContext;
                Engine.Command_TALK(character);
                Engine.PrintState();
            }
        }
    }
}
