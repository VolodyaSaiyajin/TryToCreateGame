
using UnityEngine;

public class SchoolGuy_IdleState : IdleState
{
    private SchoolGuy _enemy;

    public SchoolGuy_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, SchoolGuy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this._enemy = enemy;
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
        if (IsIdleTimeOver)
        {
            stateMachine.ChangeState(_enemy.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
