using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ILockable
    {
        bool IsLocked { get; } // Defines if is the game object locked or not
        ItemType RequiredItem { get; } // If it's locked, defines which item is required to unlock it
        bool CanUnlock(ItemType item);  // Should validate if the user can unlock the game object with some of the objects in his inventory
        // void Lock(); Keep it for future improvements, but not needed for now
        void Unlock(); // Unlocks the game object
    }
}