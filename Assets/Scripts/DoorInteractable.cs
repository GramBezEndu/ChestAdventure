using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();
        WindowManager.Instance.ToggleNeedKey();
    }
}
