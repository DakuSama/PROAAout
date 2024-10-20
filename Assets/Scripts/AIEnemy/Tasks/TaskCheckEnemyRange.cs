using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCheckEnemyRange : BehaviorTree.Node
{
    private int _enemyLayerMarck = 1 << LayerMask.NameToLayer("Player");
    private Transform _selfTransform;
    private float _fovRange;

    public TaskCheckEnemyRange(Transform selfTransform, float fovRange)
    {
        _selfTransform = selfTransform;
        _fovRange = fovRange;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        //Debug.Log("checkenemyin range");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_selfTransform.position, _fovRange, _enemyLayerMarck);

        if (colliders.Length > 0)
        {
            SetData("Target", colliders[0].transform);
            return BehaviorTree.NodeState.SUCCESS;
        }
        return BehaviorTree.NodeState.FAILURE;
    }
}
