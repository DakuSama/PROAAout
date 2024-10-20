using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public float elapsedTime, radius, maxEnemy;
    float countTime, countPickup;
    private GameState gameState;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    void Start()
    {
        countTime = elapsedTime;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        gameState = state;
    }

    void Update()
    {
        if(!(gameState == GameState.Death))
        {
            if (countPickup < maxEnemy)
            {
                elapsedTime -= Time.deltaTime;
            }

            if (elapsedTime < 0 && countPickup < maxEnemy)
            {
                SpawnObjectAtRandom();
                countPickup++;
                elapsedTime = countTime;
            }
        }
    }

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * radius;

        Instantiate(Enemy, randomPos, Quaternion.identity);
    }

    public void test()
    {
        countPickup--;
        Debug.LogWarning("changer le nom de la fonction");
    }
}
