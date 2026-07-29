using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class OpenDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private float openAngle = 90f;
        [SerializeField] private float openSpeed = 2f;
        private bool isOpen = false;
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
    }
}