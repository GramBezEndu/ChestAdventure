using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private Material glow;

    private new Renderer renderer;

    private Material original;

    public void OnFocus()
    {
        Debug.Log("Interactable.OnFocus()");
        renderer.material = glow;
    }

    public void OnFocusLost()
    {
        Debug.Log("Interactable.OnFocusLost()");
        renderer.material = original;
    }

    private void Awake()
    {
        renderer = GetComponentInChildren<Renderer>();
        original = renderer.material;
    }
}
