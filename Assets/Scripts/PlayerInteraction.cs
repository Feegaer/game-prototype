using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera     playerCamera;
    [SerializeField] private float      interactionDistance = 2f;
    [SerializeField] private LayerMask  interactionLayer;

    private IInteractable currentInteractable;
    void Awake()
    {
        interactionLayer = LayerMask.GetMask("Interactive Object");
    }
    // Update is called once per frame
    void Update()
    {
        DetectInteractable();
    }
    /// <summary>
    /// When user interact with an object while pressing "E" it trigger the event from that object
    /// </summary>
    /// <param name="value">Expecting for "E" key</param>
    public void OnInteract(InputValue value)
    {
        if (!value.isPressed) return;
        if (value.isPressed)
        {
            Debug.Log("Interact button was pressed.");
            if(currentInteractable != null) currentInteractable?.Interact();
            
        }
    }
    /// <summary>
    /// Detects an interactable object with raycast and store the game object as a var for use it later
    /// </summary>
    void DetectInteractable()
    {
        Vector3 cameraCurrentPosition = playerCamera.transform.position; // Gets the current position of the camera
        Vector3 cameraForwardViewPosition = playerCamera.transform.forward; // Gets from the current position of the camera the distance forward from it
        RaycastHit hit;

        if (Physics.Raycast(cameraCurrentPosition, cameraForwardViewPosition, out hit, interactionDistance, interactionLayer))
        {
            Debug.DrawRay(cameraCurrentPosition, cameraForwardViewPosition * hit.distance, Color.yellow);
            //Debug.Log($"Hit object: {hit.collider.gameObject.name}");
            //Debug.Log($"Interactable: {currentInteractable}");
            currentInteractable = hit.collider.GetComponent<IInteractable>();
            // Debug.Log("Interactive Object was hitted");
        }
        else
        {
            Debug.DrawRay(cameraCurrentPosition, cameraForwardViewPosition * interactionDistance, Color.white);
            currentInteractable = null;
            // Debug.Log("Interactive Object was not hitted");
        }
    }
}
