using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private const string BestTimeIdentifier = "BestTime";

    private static GameStateManager instance;

    [SerializeField]
    private GameOver gameOver;

    [SerializeField]
    private Gameplay gameplay;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private ShowBestTime showBestTime;

    private GameTimer gameTimer;

    private bool gameOverRequested;

    private float bestTime = float.MaxValue;

    public static GameStateManager Instance => instance;

    public void RequestGameOver()
    {
        gameOverRequested = true;
    }

    public void RestartGame()
    {
        mainMenu.SetActive(false);
        gameplay.StartGame();
        gameOver.Hide();
    }

    private void ShowGameOverScreen()
    {
        float finalTime = gameTimer.Time;
        if (finalTime < bestTime)
        {
            bestTime = finalTime;
        }

        PlayerPrefs.SetFloat(BestTimeIdentifier, bestTime);
        gameOver.Show(finalTime, bestTime);
    }

    private void HideTimer()
    {
        timer.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
        if (Save.HasBestTime())
        {
            bestTime = Save.GetBestTime();
            showBestTime.Time = bestTime;
        }

        mainMenu.SetActive(true);
        gameTimer = timer.GetComponent<GameTimer>();
    }

    private void LateUpdate()
    {
        if (gameOverRequested)
        {
            Debug.Log("GameStateManager.GameOver()");
            gameplay.EndGame();
            HideTimer();
            ShowGameOverScreen();

            gameOverRequested = false;
        }
    }
}
