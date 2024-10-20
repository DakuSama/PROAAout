using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree = BehaviorTree.Tree;
using UnityEngine.AI;

public class BTEnemy : Tree
{
    public float speed, fovRange, radiusPatrol;
    public int damage;
    public NavMeshAgent agent;
    public Enemy enemy;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new TaskCheckInRange(transform),
                new TaskAttack(damage)
            }),
            new Sequence(new List<Node>
            {
                new TaskCheckEnemyRange(transform, fovRange),
                new TaskGoToTarget(speed, agent)
            }),
            new Sequence(new List<Node>
            {
                new TaskRandomPosition(agent, radiusPatrol)
            })
        });
        return root;
    }
}
