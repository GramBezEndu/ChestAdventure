using Cinemachine;
using System;
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

    public PlayerInput PlayerInput
    {
        get
        {
            if (playerInput != null)
            {
                return playerInput;
            }

            playerInput = GetComponent<PlayerInput>();
            if (playerInput == null)
            {
                throw new InvalidOperationException("Player input is not accessible");
            }

            return playerInput;
        }
    }

    public void Update()
    {
        if (Physics.Raycast(camera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactDistance, ~nonInteractionLayer))
        {
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
            CurrentInteractable.OnInteract(gameObject);
        }
    }

    public void SetInputActive(bool inputActive)
    {
        SetPlayerInput(inputActive);
        bool mouseActive = !inputActive;
        Debug.Log("Mouse active: " + mouseActive);
        if (inputActive)
        {
            SetCursorState(mouseActive);
        }
        else
        {
            SetCursorState(mouseActive);
        }

        void SetPlayerInput(bool active)
        {
            if (active)
            {
                PlayerInput.ActivateInput();
            }
            else
            {
                PlayerInput.DeactivateInput();
            }
        }
    }

    private void SetCursorState(bool active)
    {
        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }
}
