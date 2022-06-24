using UnityEngine;

public class SchoolGuy_EnemyDetectState : EnemyDetectState
{
    public SchoolGuy_EnemyDetectState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_EnemyDetectState enemyDetectedState , SchoolGuy enemy) : base(entity, stateMachine, animBoolName)
    {
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
