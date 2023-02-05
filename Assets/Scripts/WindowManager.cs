using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private static WindowManager instance;

    [SerializeField]
    private GameObject needKeyPanel;

    [SerializeField]
    public GameObject openConfirm;

    [SerializeField]
    private InteractWithObject interactWithObject;

    public static WindowManager Instance => instance;

    public GameObject OpenConfirm => openConfirm;

    public GameObject NeedKey => needKeyPanel;

    public Interactable CurrentInteractable { get; private set; }

    public GameObject CurrentPanel { get; private set; }

    public void Open(GameObject panel, Interactable sender)
    {
        CurrentPanel = panel;
        CurrentInteractable = sender;
        CurrentPanel.SetActive(true);
        interactWithObject.SetInputActive(false);
    }

    public void Close(GameObject panel)
    {
        panel.SetActive(false);
        CurrentPanel = null;
        CurrentInteractable = null;
        interactWithObject.SetInputActive(true);
    }

    public void Confirm()
    {
        CurrentInteractable.OnConfirm();
        Close(CurrentPanel);
    }

    private void Awake()
    {
        instance = this;
    }
}
