using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    [Header("UI")]
    public Text pickupText;
    public Text timerText;
    public GameObject endGamePanel;
    public Text endGameText;
    public Stopwatch stopwatch;

    [Header("Pickups")]
    public Pickup[] pickups;

    private int collected = 0;
    private float timer = 0f;
    private bool gameFinished = false;

    void Start()
    {
        stopwatch.StartStopwatch();
        if (pickups == null || pickups.Length == 0)
            pickups = FindObjectsOfType<Pickup>();

        UpdatePickupText();
        endGamePanel.SetActive(false);
    }

    void Update()
    {
        if (gameFinished) return;

        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1") + "s";
    }

    public void CollectPickup(Pickup pickup)
    {
        collected++;
        UpdatePickupText();

        if (collected >= pickups.Length)
        {
            FinishGame();
        }
    }

    void UpdatePickupText()
    {
        pickupText.text = "Pickups: " + collected + " / " + pickups.Length;
    }

    void FinishGame()
    {
        stopwatch.StopStopwatch();
        endGamePanel.SetActive(true);
        endGameText.text = "You collected all pickups!\nTime: " + timer.ToString("F2") + "s";
    }
}