using UnityEngine;

public class Chest : Interactable
{
    public override void OnInteract(GameObject player)
    {
        base.OnInteract(player);
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
