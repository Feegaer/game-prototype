using Assets.Scripts.Interfaces;
using UnityEngine;

public class PickupObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log($"Picked up: {gameObject.name}");
        Destroy(gameObject);
    }
}
