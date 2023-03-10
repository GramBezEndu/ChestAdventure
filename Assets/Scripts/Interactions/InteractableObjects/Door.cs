using UnityEngine;

public class Door : Interactable
{
    public override void OnInteract(GameObject player)
    {
        base.OnInteract(player);
        WindowManager windowManager = WindowManager.Instance;
        Inventory inventory = player.GetComponent<Inventory>();
        if (!inventory.AcquiredKey)
        {
            windowManager.Open(windowManager.NeedKey, this);
        }
        else
        {
            windowManager.Open(windowManager.OpenConfirm, this);
        }
    }

    public override void OnConfirm()
    {
        base.OnConfirm();
        AllowInteraction = false;
        Debug.Log("Requested to end level!");
        GameStateManager.Instance.RequestGameplayEnd();
    }
}
