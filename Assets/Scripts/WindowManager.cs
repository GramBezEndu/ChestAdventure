using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private static WindowManager instance;

    [SerializeField]
    private GameObject needKeyPanel;

    [SerializeField]
    private InteractWithObject interactWithObject;

    public static WindowManager Instance => instance;

    public void ToggleNeedKey()
    {
        needKeyPanel.SetActive(!needKeyPanel.activeInHierarchy);
        interactWithObject.SetInputActive(!needKeyPanel.activeInHierarchy);
    }

    private void Awake()
    {
        instance = this;
    }
}
