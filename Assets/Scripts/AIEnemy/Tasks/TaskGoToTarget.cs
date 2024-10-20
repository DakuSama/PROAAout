using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskGoToTarget : BehaviorTree.Node
{
    private float _speed;
    private Transform _selfTransform;
    private Transform _targetTarnform;
    private NavMeshAgent _agent;


    public TaskGoToTarget(float speed, NavMeshAgent agent)
    {
        _speed = speed;
        _selfTransform = agent.transform;
        this._agent = agent;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        //Debug.Log("gototarget");

        if (GetData("Target") != null)
        {
            _targetTarnform = (Transform)GetData("Target");
            if (_targetTarnform == null)
            {
                ClearData("Target");
                return BehaviorTree.NodeState.FAILURE;
            }
            if (Vector3.Distance(_selfTransform.position, _targetTarnform.position) < 1.5f)
            {
                //_selfTransform.position = _targetTarnform.position;
            }
            else
            {
                _agent.SetDestination(_targetTarnform.position);
            }


            return BehaviorTree.NodeState.SUCCESS;
        }
        else
        {
            return BehaviorTree.NodeState.FAILURE;
        }
    }
}
