using UnityEngine;

public class SchoolGuy_AttackState : AttackState
{
    private StateSelector _enemy;
    public SchoolGuy_AttackState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName, D_AttackState attackState, StateSelector enemy) : base(entityAnimation, stateMachine, animBoolName, attackState)
    {
        _enemy = enemy;
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
    }

}
