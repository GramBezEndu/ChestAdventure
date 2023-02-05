using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InteractWithObject : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private float interactDistance = 10f;

    [SerializeField]
    private Vector3 interactionRayPoint = default;

    [SerializeField]
    private LayerMask interactionLayer;

    private PlayerInput playerInput;

    private InputAction interactAction;

    public void Update()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
            interactAction = playerInput.actions["interact"];
        }

        if (interactAction != null)
        {
            if (Physics.Raycast(camera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactDistance))
            {
                if (hit.collider.gameObject.layer == (int)Mathf.Log(interactionLayer.value, 2))
                {
                    Debug.Log("Looking at interactable");
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable)
                    {
                        interactable.OnFocus();
                    }
                    else
                    {
                        Debug.LogError("Interactable script was not found!");
                    }
                }
            }
        }
    }

    public void OnInteract()
    {
        Debug.Log("OnInteract() called");
    }
}
