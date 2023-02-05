using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private Material glow;

    private new Renderer renderer;

    private Material original;

    private bool allowInteraction = true;

    public bool AllowInteraction 
    {
        get => allowInteraction;
        set
        {
            if (allowInteraction != value)
            {
                allowInteraction = value;
                if (allowInteraction == false)
                {
                    renderer.material = original;
                }
            }
        }
    }
    public virtual void OnFocus()
    {
        Debug.Log("Interactable.OnFocus()");
        renderer.material = glow;
    }

    public virtual void OnFocusLost()
    {
        Debug.Log("Interactable.OnFocusLost()");
        renderer.material = original;
    }

    public virtual void OnInteract()
    {
        Debug.Log("Interactable.OnInteract()");
    }

    public virtual void OnConfirm()
    {
        Debug.Log("Interactable.OnConfirm()");
    }

    private void Awake()
    {
        renderer = GetComponentInChildren<Renderer>();
        original = renderer.material;
    }
}
