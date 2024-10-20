using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskRandomPosition : BehaviorTree.Node
{
    private NavMeshAgent _agent;
    private float _radius;
    private bool waiting = true;
    private Vector3 randomPos;

    public TaskRandomPosition(NavMeshAgent agent, float radius)
    {
        this._agent = agent;
        this._radius = radius;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        if (waiting)
        {
            waiting = false;
            randomPos = Random.insideUnitCircle * _radius;
        }
        else
        {
            
            //Debug.Log(randomPos);
            if (Vector3.Distance(_agent.transform.position, randomPos) < 0.1f)
            {
                waiting = true;
                return BehaviorTree.NodeState.SUCCESS;
            }
            else
            {
                _agent.SetDestination(randomPos);
            }
        }
        
        return BehaviorTree.NodeState.RUNNING;
    }
}
