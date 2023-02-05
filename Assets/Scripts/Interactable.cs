using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private new Renderer renderer;

    public void OnFocus()
    {
        Debug.Log("Interactable.OnFocus()");
        renderer.material.color = Color.red;
    }

    private void Awake()
    {
        renderer = GetComponentInChildren<Renderer>();
    }
}
