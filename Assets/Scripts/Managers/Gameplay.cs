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

    private Vector3 spawnPoint;

    private Quaternion spawnRotation;

    private CharacterController characterController;

    private Inventory inventory;

    public GameTimer GameTimer { get; private set; }

    public Interact Interact { get; private set; }

    public void StartGame()
    {
        level.SetActive(true);
        timerDisplay.SetActive(true);
        GameTimer.Restart();
        TeleportPlayerToSpawn();
        inventory.AcquiredKey = false;
        RegenerateMap();
        Interact.SetInputActive(true);
    }

    public void EndGame()
    {
        Debug.Log("Gameplay.EndGame()");
        Interact.SetInputActive(false);
        timerDisplay.SetActive(false);
    }

    private void TeleportPlayerToSpawn()
    {
        characterController.enabled = false;
        player.transform.SetPositionAndRotation(spawnPoint, spawnRotation);
        characterController.enabled = true;
    }

    private void RegenerateMap()
    {
        chestGenerator.RestoreUsedObject();
        chestGenerator.Generate();
        doorGenerator.RestoreUsedObject();
        doorGenerator.Generate();
    }

    private void Awake()
    {
        level.SetActive(false);
        GameTimer = timerDisplay.GetComponent<GameTimer>();
        Interact = player.GetComponent<Interact>();
        characterController = player.GetComponent<CharacterController>();
        inventory = player.GetComponent<Inventory>();

        spawnPoint = player.transform.position;
        spawnRotation = player.transform.rotation;
    }
}
