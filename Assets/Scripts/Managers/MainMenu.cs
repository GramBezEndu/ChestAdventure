using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private ShowBestTime showBestTime;

    public void Show()
    {
        mainMenu.SetActive(true);
        if (Save.HasBestTime())
        {
            showBestTime.Time = Save.GetBestTime();
        }
    }

    public void Hide()
    {
        mainMenu.SetActive(false);
    }
}
