using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private Material glow;

    [SerializeField]
    private int nonInteractableLayer;

    private new Renderer renderer;

    private Material original;

    private bool allowInteraction = true;

    public bool AllowInteraction 
    {
        get => allowInteraction;
        set
        {
            if (allowInteraction != value)
            {
                allowInteraction = value;
                if (allowInteraction == false)
                {
                    renderer.material = original;
                    int layer = nonInteractableLayer;
                    gameObject.layer = layer;
                    foreach (Transform transform in gameObject.transform.GetComponentsInChildren<Transform>())
                    {
                        transform.gameObject.layer = layer;
                    }
                }
            }
        }
    }

    public GameObject Player { get; private set; }

    public virtual void OnFocus()
    {
        Debug.Log("Interactable.OnFocus()");
        renderer.material = glow;
    }

    public virtual void OnFocusLost()
    {
        Debug.Log("Interactable.OnFocusLost()");
        renderer.material = original;
    }

    public virtual void OnInteract(GameObject player)
    {
        Player = player;
        Debug.Log("Interactable.OnInteract()");
    }

    public virtual void OnConfirm()
    {
        Debug.Log("Interactable.OnConfirm()");
    }

    private void Awake()
    {
        renderer = GetComponentInChildren<Renderer>();
        original = renderer.material;
    }
}
