using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public static PickupManager Instance { get; private set; }
    // instance property allows other scripts to access the functionality of this script without needing a 
    //direct refrence to an instance this script.
    public GameObject pickupPrefab; 
    private GameObject currentPickup; 
    
    private void Awake()
    {
        //Instance = null;
        
        if (Instance != null)
        {
            Destroy (Instance.gameObject);
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-9, 9), .5f, UnityEngine.Random.Range(-9, 9));
            transform.position = randomPosition;

        
        }
        
        Instance = this; // ensurs there is only one instance of pickup
        currentPickup = gameObject;
    }

   

    public void RespawnPickup()
    {

       

        currentPickup = Instantiate(pickupPrefab);

    }
}

