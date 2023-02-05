using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    // TODO: Implement player inventory check
    private bool hasKey = true;

    public override void OnInteract()
    {
        base.OnInteract();
        if (!hasKey)
        {
            WindowManager.Instance.ToggleNeedKey();
        }
        else
        {
            WindowManager.Instance.ToogleOpenDoor();
        }
    }
}
