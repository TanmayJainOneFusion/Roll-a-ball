using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubePrefab;


    // Update is called once per frame
    private void Start()
    {


        Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-9, 9), .5f, UnityEngine.Random.Range(-9, 9));
        transform.position = randomSpawnPosition;




    }

  
}
