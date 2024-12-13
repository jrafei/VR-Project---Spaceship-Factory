using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftControllerInteraction : MonoBehaviour
{
    //public string screwButton = "Fire1"; // Bouton pour visser (configur� dans Input Manager)
    private ScrewInteraction currentScrew;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ScrewInteraction>())
        {
            currentScrew = other.GetComponent<ScrewInteraction>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (currentScrew != null && other.GetComponent<ScrewInteraction>() == currentScrew)
        {
            currentScrew = null;
        }
    }

    void Update()
    {
        if (currentScrew != null ) //&& Input.GetButtonDown(screwButton)
        {
            Debug.Log(" [LeftControllerInteraction] Start screwing !");
            currentScrew.Screw();
        }
    }
}
