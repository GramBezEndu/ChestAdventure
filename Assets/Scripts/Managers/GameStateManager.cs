using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private const string BestTimeIdentifier = "BestTime";

    private static GameStateManager instance;

    private readonly List<float> completionTimes = new List<float>();

    [SerializeField]
    private GameOver gameOver;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private ObjectGenerator chestGenerator;

    [SerializeField]
    private ObjectGenerator doorGenerator;

    [SerializeField]
    private GameObject level;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private ShowBestTime showBestTime;

    private Interact interactWithObject;

    private Vector3 spawnPoint;

    private Quaternion spawnRotation;

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
        level.SetActive(true);
        timer.SetActive(true);
        gameTimer.Restart();
        gameOver.Hide();
        interactWithObject.SetInputActive(true);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.SetPositionAndRotation(spawnPoint, spawnRotation);
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Inventory>().AcquiredKey = false;

        chestGenerator.RestoreUsedObject();
        chestGenerator.Generate();

        doorGenerator.RestoreUsedObject();
        doorGenerator.Generate();
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
            float bestTime = Save.GetBestTime();
            completionTimes.Add(bestTime);
            showBestTime.Time = bestTime;
        }

        mainMenu.SetActive(true);
        level.SetActive(false);
        gameTimer = timer.GetComponent<GameTimer>();
        interactWithObject = player.GetComponent<Interact>();
        spawnPoint = player.transform.position;
        spawnRotation = player.transform.rotation;
        Debug.Log("Spawn point: " + spawnPoint);
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
