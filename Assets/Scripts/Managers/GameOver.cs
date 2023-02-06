using System;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private TextMeshProUGUI finalTimeText;

    [SerializeField]
    private TextMeshProUGUI bestTimeText;

    public void Show(float finalTime, float bestTime)
    {
        gameOver.SetActive(true);
        finalTimeText.text = "Final time: " + GameTimer.FormatTime(TimeSpan.FromSeconds(finalTime));
        bestTimeText.text = "Best time: " + GameTimer.FormatTime(TimeSpan.FromSeconds(bestTime));
    }

    public void Hide()
    {
        gameOver.SetActive(false);
    }
}
