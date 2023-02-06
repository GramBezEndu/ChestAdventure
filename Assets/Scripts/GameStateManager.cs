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
    private GameObject player;

    private InteractWithObject interactWithObject;

    private Vector3 spawnPoint;

    private Quaternion spawnRotation;

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
        gameOver.SetActive(false);
        interactWithObject.SetInputActive(true);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = spawnPoint;
        player.transform.rotation = spawnRotation;
        Debug.Log("position after teleport: " + player.gameObject.transform.position);
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Inventory>().AcquiredKey = false;
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

    private void HideTimer()
    {
        timer.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
        gameTimer = timer.GetComponent<GameTimer>();
        interactWithObject = player.GetComponent<InteractWithObject>();
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
