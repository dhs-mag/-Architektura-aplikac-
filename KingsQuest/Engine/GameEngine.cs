using System.Collections.Concurrent;
using Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using Data.Things;
using Data.Things.Contract;

namespace Engine
{
    public class GameEngine
    {
        public Room CurrentRoom { get; private set; }
        
        public Player CurrentPlayer { get; private set; }

        /// <summary>
        /// List o adjacent rooms available for legal moves
        /// </summary>
        public List<Room> AdjacentRooms => CurrentRoom.RoomsAround;

    public void GameInit()
        {
            // init player
            
            CurrentPlayer = new Player(6);
            CurrentPlayer.Inventory.Add(new Coin("A gold coin"));
            
            // init world
            
            Room forest = new Room()
            {
                Name = "🏞 Forest",
                Description = "You are in a Forest! 🏞 ️ You know nothing about the Forest John! \n\nChoose your path.\n\nThere's one leading to a nearby town and one leading into the deep forest."
            };
            Room deepForest = new Room()
            {
                Name = "🛤 Deep forest",
                Description = "It's so dark you can barely see....🤷 \n\nOuch! 😲 What the hell was that?! 😤 \n\nA deadly spider has bitten you, you can't feel your legs. 🕷 Guess you are not going anywhere now 😵"
            };
            Room town = new Room()
            {
                Name = "⛩ Town",
                Description = "You are entering the local town of Ooobelyboo.\n\nJolly folk 💃🕺 from local tavern runs around a sings silly drunken songs. 🍻🎶\n\nYou can hear clinking of the blacksmith's hammer in the background. ⚒"
            };
            Room tavern = new Room()
            {
                Name = "🍻 Tavern",
                Description = "So nice to see a nice tavern like this!\n\nI guess you know what taverns are for. 😈 Have a look around. 👀"
            };
            Room bar = new Room()
            {
                Name = "🍺 Bar",
                Description = "Oh oh! No money, no beer fellow! 💸🤬"
            };
            Room chamber = new Room()
            {
                Name = "🚪 Chamber",
                Description = "You are in a black chamber! 😨\n\nYou are better off returning back to the tavern I guess... 🤔",
                ThingsInside = new List<Thing>()
                {
                    new Coin("Bag of cash")
                }
            };
            Room blacksmiths = new Room()
            {
                Name = "⚒ Blacksmith's workshop",
                Description = "A fine sword takes shape in the blacksmith's skillful hands. ⚒ Too bad you have no money to buy it. ☹"
            };
            
            forest.RoomsAround.Add(town);
            forest.RoomsAround.Add(deepForest);
            
            town.RoomsAround.Add(tavern);
            town.RoomsAround.Add(blacksmiths);
            town.RoomsAround.Add(forest);
            
            tavern.RoomsAround.Add(chamber);
            tavern.RoomsAround.Add(bar);
            tavern.RoomsAround.Add(town);

            bar.RoomsAround.Add(tavern);
            chamber.RoomsAround.Add(tavern);
            
            blacksmiths.RoomsAround.Add(town);
            
            CurrentRoom = forest;
        }

        /// <summary>
        /// Move to another room within the map bounds.
        /// </summary>
        /// <param name="room">Destination room</param>
        /// <returns>TRUE on successful move, FALSE in case of the intended move is invalid</returns>
        public bool MoveTo(Room room)
        {
            if (!AdjacentRooms.Contains(room)) return false;
            
            CurrentRoom = room;
            return true;
        }

        public bool Pick(IPickable thing)
        {
            var success = CurrentPlayer.Inventory.Add(thing);
            if (!success) return false;

            return true;
        }

        public bool ActUpon<TThing>(TThing thing, Thing responder) where TThing : Thing
        {
            if (responder is IResponsiveTo<TThing> responsiveResponder)
            {
                var success = responsiveResponder.RespondTo(thing, CurrentPlayer);
                if (!success) return false;

                if (thing is IConsumable consumableActor)
                {
                    consumableActor.Dispose();
                }
            }

            return false;
        }

        /// <summary>
        /// Generate textual description of the current game state.
        /// </summary>
        /// <returns></returns>
        public string GetStateDescription(bool includeLocationHints = true)
        {
            var sb = new StringBuilder();
            sb.AppendLine(CurrentRoom.Description);

            if (!includeLocationHints)
                return sb.ToString();
            
            sb.AppendLine("\nAround you are:");
            if (AdjacentRooms.Any())
            {
                for (var index = 0; index < AdjacentRooms.Count; index++)
                {
                    var room = AdjacentRooms[index];
                    sb.AppendLine($"{index + 1}) {room.Name}");
                }
            }
            else
            {
                sb.AppendLine("\nThere is nothing around you.");
            }

            return sb.ToString();
        }
    }
}
