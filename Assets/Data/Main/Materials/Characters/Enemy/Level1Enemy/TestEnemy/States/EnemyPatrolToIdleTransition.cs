using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolToIdleTransition : Transition
{
    [SerializeField] private D_EntityVisibility _entityVisibility;
    [SerializeField] private EnemyLookAround _enemyLook;

    private PatrolState _patrolState;

    public override void Enable()
    {
        
    }
    private void Update()
    {
        CheckEnemy();
        ChangeStateToIdle();
    }

    private void CheckEnemy()
    {
        if (_enemyLook.IsSeeEnemy() == true)
        {
            IsNeedTransition = true;
            Debug.Log("CheckEnemy");
        }
    }

    private void ChangeStateToIdle()
    {
        if (_enemyLook.CheckLedge() == true)
        {
            IsNeedTransition = true;
            Debug.Log("ChangeStateToIdle");
        }
    }
}
