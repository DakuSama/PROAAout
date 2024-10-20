using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCheckInRange : BehaviorTree.Node
{
    private Transform _transform;
    private Transform _target;

    public TaskCheckInRange(Transform transform)
    {
        _transform = transform;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        //Debug.Log("check in range");
        if (GetData("Target") != null)
        {
            _target = (Transform)GetData("Target");
            if (_target == null)
            {
                ClearData("Target");
                return BehaviorTree.NodeState.FAILURE;
            }
            if (Vector3.Distance(_transform.position, _target.position) < 1f)
            {
                return BehaviorTree.NodeState.SUCCESS;
            }
            else
            {
                return BehaviorTree.NodeState.FAILURE;
            }

        }
        else
        {
            return BehaviorTree.NodeState.FAILURE;
        }
    }
}
