using Data;

namespace Engine
{
    public interface IUserInterface
    {
        void ShowTalk(string dialogLine, Character whoIsTalking = null);
        
        void IndicateInventoryAddition(Item item);
        
        void CurrentRoomTransition(Room oldRoom, Room newRoom);
        
        void IndicateExit();
    }
}