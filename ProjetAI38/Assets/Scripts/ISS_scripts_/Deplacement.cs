/*
 faire déplacer l'utilisateur en fonction de l'entrée joystick
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Deplacement : MonoBehaviour
{
    [SerializeField] private bool droite;
    [SerializeField] private GameObject cam;
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty grabAction;
    [SerializeField] private float maxVelocity = 5f;
    [SerializeField] private float moveForceMultiplier = 10f;

    private Rigidbody rb;
    private ParticleSystem.EmissionModule emission;
    private bool holding;
    private bool inzone;
    private Vector3 start;
    private Vector3 end;

    void Start()
    {
        rb = cam.GetComponent<Rigidbody>();
        emission = GetComponentInChildren<ParticleSystem>().emission;
        emission.enabled = false;

        grabAction.action.Enable();
        moveAction.action.Enable();
    }

    void Update()
    {
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }

        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            Vector3 forceDirection = droite ? transform.forward : -transform.forward;
            rb.AddForce(forceDirection * moveForceMultiplier * moveInput.y);
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }

        if (grabAction.action.WasPressedThisFrame())
        {
            start = transform.position;
            holding = true;
            Debug.Log("Grab started");
        }

        if (grabAction.action.WasReleasedThisFrame() && holding)
        {
            end = transform.position;
            holding = false;
            rb.AddForce((start - end) * 20);
            Debug.Log("Grab released");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            inzone = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            inzone = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Debug.Log("Projection triggered");
            rb.AddForce(-transform.forward * 2, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset projection state
    }
}
