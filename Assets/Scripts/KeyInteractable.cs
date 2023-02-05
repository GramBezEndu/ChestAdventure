using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : Interactable
{
    public override void OnInteract(GameObject player)
    {
        base.OnInteract(player);
        WindowManager windowManager = WindowManager.Instance;
        windowManager.Open(windowManager.TakeKey, this);
    }

    public override void OnConfirm()
    {
        base.OnConfirm();
        AllowInteraction = false;
        Inventory inventory = Player.GetComponent<Inventory>();
        inventory.AcquiredKey = true;
        Destroy(gameObject);
    }
}