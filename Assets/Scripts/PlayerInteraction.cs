using UnityEngine;
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera     playerCamera;
    [SerializeField] private float      interactionDistance = 2f;
    [SerializeField] private LayerMask  interactionLayer;
    void Awake()
    {
        interactionLayer = LayerMask.GetMask("Interactive Object");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectInteractable();
    }

    void DetectInteractable()
    {
        Vector3 cameraCurrentPosition = playerCamera.transform.position;
        Vector3 cameraForwardViewPosition = playerCamera.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(cameraCurrentPosition, cameraForwardViewPosition, out hit, interactionDistance, interactionLayer))
        {
            Debug.DrawRay(cameraCurrentPosition, cameraForwardViewPosition * hit.distance, Color.yellow);
            Debug.Log("Interactive Object was hitted");
        }
        else
        {
            Debug.DrawRay(cameraCurrentPosition, cameraForwardViewPosition * interactionDistance, Color.white);
            Debug.Log("Interactive Object was not hitted");
        }
    }
}
