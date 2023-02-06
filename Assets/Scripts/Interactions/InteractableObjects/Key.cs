using UnityEngine;

public class Key : Interactable
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
        gameObject.SetActive(false);
    }
}
