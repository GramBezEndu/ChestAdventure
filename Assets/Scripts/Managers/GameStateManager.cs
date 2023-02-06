using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance;

    [SerializeField]
    private GameOver gameOver;

    [SerializeField]
    private Gameplay gameplay;

    [SerializeField]
    private MainMenu mainMenu;

    private bool gameplayEndRequested;

    private float bestTime = float.MaxValue;

    public static GameStateManager Instance => instance;

    public void RequestGameplayEnd()
    {
        gameplayEndRequested = true;
    }

    public void RestartGame()
    {
        mainMenu.Hide();
        gameOver.Hide();
        gameplay.StartGame();
    }

    private void ShowGameOverScreen()
    {
        float finalTime = gameplay.GameTimer.Time;
        if (finalTime < bestTime)
        {
            bestTime = finalTime;
        }

        Save.SaveBestTime(bestTime);
        gameOver.Show(finalTime, bestTime);
    }

    private void Awake()
    {
        instance = this;
        if (Save.HasBestTime())
        {
            bestTime = Save.GetBestTime();
        }

        mainMenu.Show();
    }

    private void LateUpdate()
    {
        if (gameplayEndRequested)
        {
            gameplay.EndGame();
            ShowGameOverScreen();

            gameplayEndRequested = false;
        }
    }
}
