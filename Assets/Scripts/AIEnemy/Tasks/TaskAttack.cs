using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskAttack : BehaviorTree.Node
{
    private DamageSystem _damageSystem;
    private Transform _target;
    private bool waiting = false;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private int _damage;

    public TaskAttack(int damage)
    {
        _damage = damage;
    }

    public override BehaviorTree.NodeState Evaluate()
    {
        //Debug.Log("TaskAttack");
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                waiting = false;

            }
        }
        else
        {
            _target = (Transform)GetData("Target");
            if (_target == null)
            {
                ClearData("Target");
                return BehaviorTree.NodeState.FAILURE;
            }
            _damageSystem = _target.transform.GetComponent<DamageSystem>();
            if (_damageSystem.TakeHit(_damage, _target))
            {
                waiting = true;
                waitCounter = 0f;
            }
            else
            {
                ClearData("Target");
            }
        }
        return BehaviorTree.NodeState.SUCCESS;
    }
}
