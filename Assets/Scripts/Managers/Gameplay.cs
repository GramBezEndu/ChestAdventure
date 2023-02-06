using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField]
    private GameObject timerDisplay;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private ObjectGenerator chestGenerator;

    [SerializeField]
    private ObjectGenerator doorGenerator;

    [SerializeField]
    private GameObject level;

    private GameTimer gameTimer;

    private Vector3 spawnPoint;

    private Quaternion spawnRotation;

    private CharacterController characterController;

    private Inventory inventory;

    public Interact Interact { get; private set; }

    public void StartGame()
    {
        level.SetActive(true);
        timerDisplay.SetActive(true);
        gameTimer.Restart();
        characterController.enabled = false;
        player.transform.SetPositionAndRotation(spawnPoint, spawnRotation);
        characterController.enabled = true;
        inventory.AcquiredKey = false;

        chestGenerator.RestoreUsedObject();
        chestGenerator.Generate();

        doorGenerator.RestoreUsedObject();
        doorGenerator.Generate();
        Interact.SetInputActive(true);
    }

    public void EndGame()
    {
        Interact.SetInputActive(false);
    }

    private void Awake()
    {
        level.SetActive(false);
        gameTimer = timerDisplay.GetComponent<GameTimer>();
        Interact = player.GetComponent<Interact>();
        characterController = player.GetComponent<CharacterController>();
        inventory = player.GetComponent<Inventory>();

        spawnPoint = player.transform.position;
        spawnRotation = player.transform.rotation;
    }
}
