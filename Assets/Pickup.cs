using UnityEngine;

public class Pickup : MonoBehaviour
{
    private int count;

    void Start() {
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
            count = count + 1;
        }
    }
}