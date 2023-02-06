using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private TextMeshProUGUI finalTimeText;

    [SerializeField]
    private TextMeshProUGUI bestTimeText;

    [SerializeField]
    private InteractWithObject interactWithObject;

    private GameTimer gameTimer;

    private bool gameOverRequested;

    private List<float> completionTimes = new List<float>();

    public static GameStateManager Instance => instance;

    public void RequestGameOver()
    {
        gameOverRequested = true;
    }

    public void RestartGame()
    {
        timer.SetActive(true);
        gameTimer.Restart();
        gameObject.SetActive(false);
        interactWithObject.SetInputActive(true);
    }

    private void HideTimer()
    {
        timer.SetActive(false);
    }

    private void ShowGameOverScreen()
    {
        gameOver.SetActive(true);
        float finalTime = gameTimer.Time;
        finalTimeText.text = "Final time: " + GameTimer.FormatTime(TimeSpan.FromSeconds(finalTime));
        completionTimes.Add(finalTime);
        completionTimes.Sort();
        float bestTime = completionTimes[0];
        bestTimeText.text = "Best time: " + GameTimer.FormatTime(TimeSpan.FromSeconds(bestTime));
    }

    private void Awake()
    {
        instance = this;
        gameTimer = timer.GetComponent<GameTimer>();
    }

    private void LateUpdate()
    {
        if (gameOverRequested)
        {
            Debug.Log("GameStateManager.GameOver()");
            interactWithObject.SetInputActive(false);
            HideTimer();
            ShowGameOverScreen();

            gameOverRequested = false;
        }
    }
}
