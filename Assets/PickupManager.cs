using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickupManager : MonoBehaviour
{
    private int count;
    private float timer;
    private bool gameOver;
    private float finalTime;

    public Text countText;
    public Text timerText;
    public Text endTime;
    public GameObject endPanel;

    public int winCount = 4;


    void Start() {
        count = 0;
        timer = 0f;
        gameOver = false;

        endPanel.SetActive(false);
        SetCountText();
    }

    void Update() {
        if (gameOver) return;

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    
    public void CollectPickup() {
        if (gameOver) return;

        count++;
        SetCountText();
    }

    void SetCountText() {
        countText.text = "Count: " + count;
        if (count >= winCount) {
            EndGame();
        }
    }
    void EndGame() {
        gameOver = true;
        finalTime = timer;
        endTime.text = "Game Over";
        endPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}