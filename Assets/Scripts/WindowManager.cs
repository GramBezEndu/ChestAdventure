using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private static WindowManager instance;

    [SerializeField]
    private GameObject needKeyPanel;

    [SerializeField]
    public GameObject openDoor;

    [SerializeField]
    private InteractWithObject interactWithObject;

    public static WindowManager Instance => instance;

    public void ToggleNeedKey()
    {
        TogglePanel(needKeyPanel);
    }

    public void ToogleOpenDoor()
    {
        TogglePanel(openDoor);
    }

    private void Awake()
    {
        instance = this;
    }

    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeInHierarchy);
        interactWithObject.SetInputActive(!panel.activeInHierarchy);
    }
}
