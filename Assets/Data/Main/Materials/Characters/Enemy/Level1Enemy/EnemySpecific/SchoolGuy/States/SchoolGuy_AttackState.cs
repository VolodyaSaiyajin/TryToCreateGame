using UnityEngine;

public class SchoolGuy_AttackState : AttackState
{
    private SchoolGuy _enemy;
    public SchoolGuy_AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState attackState, SchoolGuy enemy) : base(entity, stateMachine, animBoolName, attackState)
    {
        _enemy = enemy;
    }

    public void Awake()
    {
        _playerEntity = _playerEntity.GetComponent<PlayerEntity>();
    }


    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Debug.Log(_playerEntity);
        MoveToEnemy();
    }

    private void MoveToEnemy()
    {
        if (_isAttacking)
        {
            _enemy.transform.position = _playerEntity.transform.position - _enemy.transform.position;
            Debug.Log(_isAttacking);
        }
    }
}
