using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int count;
    public Text countText;
    public Text endGameText;

    void Start() {
        count = 0;
        SetCountText();
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

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 4) {
            endGameText.text = "Game Over! Time: ";
        }
    }
}