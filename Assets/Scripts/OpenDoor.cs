using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class OpenDoor : MonoBehaviour, IInteractable, ILockable
    {
        [SerializeField] private float openAngle = 90f;
        [SerializeField] private float openSpeed = 2f;
        [SerializeField] private bool isLocked = false;
        [SerializeField] private bool isOpen = false;
        [SerializeField] private ItemType requiredItem;

        public void Interact()
        {
            isOpen = !isOpen;

            if(isOpen)
            {
                // Open the door
                transform.Rotate(0, 0, openAngle, Space.Self);
            }
            else
            {
                // Close the door
                transform.Rotate(0, 0, -openAngle, Space.Self);
            }
        }
        public string InteractionPrompt => "Press [E] to open door.";
        public bool IsLocked => isLocked;
        public ItemType RequiredItem => requiredItem;
        public bool CanUnlock(ItemType item) => item == requiredItem;
        public void Unlock() => isLocked = false;
    }
}