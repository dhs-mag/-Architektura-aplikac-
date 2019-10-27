﻿using System.Collections.Concurrent;
using Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Engine
{
    public class GameEngine
    {
        public Room CurrentRoom { get; private set; }

        /// <summary>
        /// List o adjacent rooms available for legal moves
        /// </summary>
        public List<Room> AdjacentRooms => CurrentRoom.RoomsAround;

    public void GameInit()
        {
            Room forest = new Room() { Name = "Forest", Description = "You are in a Forest! You know nothing about the Forest John! \nChoose your path." };
            Room chamber = new Room() { Name = "Chamber", Description = "You are in a black chamber!\nYou are better off returning back to the forest I guess..." };
            
            chamber.RoomsAround.Add(forest);
            forest.RoomsAround.Add(chamber);
            
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
