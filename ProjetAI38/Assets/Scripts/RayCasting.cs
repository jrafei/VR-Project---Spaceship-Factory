using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycasting : MonoBehaviour
{

    /**
     * This class creates a radius from the camera to the cursor 
       position in the 3D environment.
     * The object carrying this script can enter objects, 
       manipulate them and move them with the left click of the mouse.
     * Three types of cursors are implemented:
     
    **/
    private Camera _mainCamera; // Camera component
    private const int _raycastDistance = 100; // Distance maximale que peut atteindre le rayon.
    private Rigidbody grabbdedObject = null; //Objet actuellement saisi
    private float offset = 0.0f; //Distance entre la caméra et l'objet saisi, pour maintenir un positionnement cohérent.

    // This variable will allow us to find the mask corresponding 
    // to the "Grabbable" layer
    private LayerMask layerGrabbable; // Masque de calque utilisé pour détecter les objets manipulables.

    // All cursor's texture to fill in the editor
    /*
    * A cursorOff when no manipulable object (grabbable tag) is 
       detected by the ray.
     * A cursorGrabbable when a manipulable object is detected 
       but not grabbed
     * A cursorGrabbed when an object is entered
    */
    public Texture2D cursorOff, cursorGrabbable, cursorGrabbed; 


    // Start is called before the first frame update
    /*
    Recherche la caméra principale via son tag.
    Charge le masque de calque "Grabbable".
    Confine le curseur dans la fenêtre de jeu (Cursor.lockState).
    */
    void Start()
    {
        // Search the component camera in the scene
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        // Search the layer with the name "Grabbable"
        layerGrabbable = LayerMask.GetMask("Grabbable"); // Récupère le masque de calque "Grabbable" , c'est pour identifier les objets manipulables.
        // The mouse cursor is forced to remain in the Game window
        Cursor.lockState = CursorLockMode.Confined;
    }

    void FixedUpdate()
    {
        // Create a ray from the center of the camera to the cursor
        //Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        // Use the new Input System to get the mouse position
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Create a ray from the camera to the cursor
        Ray ray = _mainCamera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0));

        
        
        Debug.DrawRay(ray.origin, ray.direction * _raycastDistance, Color.yellow);

        // If a GameObject is already grabbed
        /*
        Si un objet est déjà saisi :
        La position de l'objet est mise à jour pour correspondre à celle du curseur, avec un décalage défini par offset.
        */
        if (grabbdedObject != null)
        {
            // Move the grabbed Gameobject together with the cursor 
            // and offset by the offset value
            Vector3 newPosition = ray.origin + (ray.direction * offset);
            grabbdedObject.MovePosition(newPosition);
        }
        else
        {
            // Nothing is grabbed, we just want to know what's grabbable 
            // and what's not
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, _raycastDistance, layerGrabbable))
            {
                updateCursor(cursorGrabbable); // We update the cursor's texture to indicate that the object is grabbable
            }
            else
            {
                updateCursor(cursorOff); // We update the cursor's texture to indicate that the object is not grabbable
            }
        }
    }

    // Action method related to the input left button (click and release)
    void OnGrab(InputValue value)
    {
        // If the button is pressed
        if (value.isPressed)
        {
            RaycastHit hit;
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
            // If the object is grabbable
            if (Physics.Raycast(ray.origin, ray.direction, out hit, _raycastDistance, layerGrabbable)) // Si l'objet est manipulable
            {
                grabbdedObject = hit.rigidbody; // We keep the object in memory to manipulate it
                offset = Vector3.Distance(ray.origin, hit.transform.position); // We calculate the distance between the camera and the object to keep a coherent positioning
                grabbdedObject.isKinematic = true; // We switch isKinematic to true to avoid physics problems (forcesphysics)
                updateCursor(cursorGrabbed); // We update the cursor's texture
            }
        }
        else // If the button is released
        {
            // Make sure you hold something tight to avoid errors
            if (grabbdedObject != null)
            {
                // Switch isKinematic to false BEFORE erasing grabbedObject overwise we can not know which object to modify
                grabbdedObject.isKinematic = false;
                grabbdedObject = null; // l'objet est relâché
            }
        }
    }
    // Update the cursor's texture
    //Met à jour l'apparence du curseur en fonction de l'état :
    void updateCursor(Texture2D tex)
    {
      // calculates the "hotspot" of the cursor which, 
      // in our image, indicates precisely what you click on
      // As we have an image of the cross, 
      // we take the center of the image
        Vector2 hotspot = new Vector2(tex.width / 2, tex.height / 2);
        Cursor.SetCursor(tex, hotspot, CursorMode.Auto);
    }
}
