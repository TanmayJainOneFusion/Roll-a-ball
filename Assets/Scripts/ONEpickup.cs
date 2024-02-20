using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public int numberOfPickups = 13;

    private int pickupsCollected = 0;

    void Start()
    {
        SpawnPickup();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // Deactivate the collected pickup.
            pickupsCollected++;
            SpawnPickup();

        }
    }

    void SpawnPickup()
    {
        if (pickupsCollected < numberOfPickups)
        {
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(pickupPrefab, randomPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("All pickups collected!");
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-9f, 9f);
        float randomZ = Random.Range(-9f, 9f);

        return new Vector3(randomX, 0.5f, randomZ);
    }
}

