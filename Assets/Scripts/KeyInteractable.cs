using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();
        WindowManager windowManager = WindowManager.Instance;
        windowManager.Open(windowManager.TakeKey, this);
    }

    public override void OnConfirm()
    {
        base.OnConfirm();
        AllowInteraction = false;
        Destroy(gameObject);
    }
}
