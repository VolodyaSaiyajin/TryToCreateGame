using UnityEngine;

public class AttackState : State
{
    protected PlayerEntity _playerEntity;
    protected D_AttackState _attackStateData;
    protected bool _isAttacking;

    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState attackState) : base(entity, stateMachine, animBoolName)
    {
        _attackStateData = attackState;
    }

    public override void Enter()
    {       
        _isAttacking = entity.CheckEnemy();        
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
    }
}
