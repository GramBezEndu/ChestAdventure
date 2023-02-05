using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    // TODO: Implement player inventory check
    private bool hasKey = false;

    public override void OnInteract()
    {
        base.OnInteract();
        WindowManager windowManager = WindowManager.Instance;
        if (!hasKey)
        {
            windowManager.Open(windowManager.NeedKey, this);
        }
        else
        {
            windowManager.Open(windowManager.OpenConfirm, this);
        }
    }
}
