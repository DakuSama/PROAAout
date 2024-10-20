using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickup;

    public float elapsedTime, radius, maxPickup;
    float countTime, countPickup;
    
    // Start is called before the first frame update
    void Start()
    {
        countTime = elapsedTime;
        for(int i = 0; i < maxPickup; i++)
        {
            SpawnObjectAtRandom();
            countPickup++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countPickup < maxPickup)
        {
            elapsedTime -= Time.deltaTime;
        }
        
        if (elapsedTime < 0 && countPickup < maxPickup)
        {
            SpawnObjectAtRandom();
            countPickup++;
            elapsedTime = countTime;
        }
    }

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * radius;

        Instantiate(pickup, randomPos, Quaternion.identity);
    }

    public void DownCountPickup()
    {
        countPickup--;
    }
}
