using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();
        WindowManager windowManager = WindowManager.Instance;
        windowManager.Open(windowManager.OpenConfirm, this);
    }

    public override void OnConfirm()
    {
        base.OnConfirm();
        AllowInteraction = false;
        Animation animation = gameObject.transform.parent.GetComponent<Animation>();
        animation.Play();
    }
}
