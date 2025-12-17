using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        PickupManager manager = FindObjectOfType<PickupManager>();

        if (manager != null) {
            manager.CollectPickup();
        }
        Destroy(gameObject);
    }
}
