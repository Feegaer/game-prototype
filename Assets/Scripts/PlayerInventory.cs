using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<ItemType> inventory = new List<ItemType>();
        public bool AddItem(ItemType item)
        {   
            if(!inventory.Contains(item))
            {
                inventory.Add(item);
                Debug.Log($"Added {item} to inventory.");
                return true;
            }
            else
            {
                Debug.Log($"Item {item} is already in inventory.");
                return false;
            }
        }

        public void RemoveItem(ItemType item) {
            Debug.Log($"Removed {item} from inventory.");
            inventory.Remove(item);
        }

        public bool HasItem(ItemType item) {
            if(inventory.Contains(item)) 
                return true;
            return false;
        }

    }
}