using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent _agent;

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
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if(state == GameState.Death)
        {
            Destroy(gameObject);
        }
    }

    public void TestPrint()
    {
        Debug.Log("test print");
    }
}
