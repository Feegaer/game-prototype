using Assets.Scripts.Interfaces;
using UnityEngine;

public class PickupObject : MonoBehaviour, IPickUp
{
    [SerializeField] ItemType item;
    public void Interact()
    {
        Debug.Log($"Picked up: {item}");
        Destroy(gameObject);
    }

    public string InteractionPrompt => $"Press [E] to pick up: {item}";

    public ItemType ItemType
    {
        get { return item; }
    }
}
