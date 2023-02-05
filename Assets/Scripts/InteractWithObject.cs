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

    [SerializeField]
    private LayerMask nonInteractionLayer;

    private PlayerInput playerInput;

    private InputAction interactAction;

    private Interactable currentInteractable;

    public Interactable CurrentInteractable
    {
        get => currentInteractable;
        private set
        {
            if (currentInteractable != value)
            {
                if (currentInteractable != null)
                {
                    currentInteractable.OnFocusLost();
                }

                currentInteractable = value;
                if (currentInteractable != null && currentInteractable.AllowInteraction)
                {
                    currentInteractable.OnFocus();
                }
            }
        }
    }

    public void Update()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
            interactAction = playerInput.actions["interact"];
        }

        if (interactAction == null)
        {
            Debug.LogError("Interactable action is null!");
            return;
        }

        if (Physics.Raycast(camera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactDistance, ~nonInteractionLayer))
        {
            Debug.Log(hit.collider.gameObject.name);

            if (interactionLayer.IsLayerInMask(hit.collider.gameObject.layer))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (!interactable)
                {
                    Debug.LogError("Interactable script was not found!");
                    return;
                }

                if (CurrentInteractable == null || hit.collider.gameObject.GetInstanceID() == CurrentInteractable.gameObject.GetInstanceID())
                {
                    CurrentInteractable = interactable;
                }
            }
            else
            {
                CurrentInteractable = null;
            }
        }
        else
        {
            CurrentInteractable = null;
        }
    }

    public void OnInteract()
    {
        if (CurrentInteractable != null && CurrentInteractable.AllowInteraction)
        {
            SetInputActive(false);
            CurrentInteractable.OnInteract();
        }
    }

    public void OnInteractionEnd()
    {
        Debug.Log("InteractWithObject.OnInteractionEnd()");
    }

    public void SetInputActive(bool inputActive)
    {
        bool mouseActive = !inputActive;
        if (inputActive)
        {
            playerInput.ActivateInput();
            SetCursorState(mouseActive);
        }
        else
        {
            playerInput.DeactivateInput();
            SetCursorState(mouseActive);
        }
    }

    private void SetCursorState(bool active)
    {
        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }
}
