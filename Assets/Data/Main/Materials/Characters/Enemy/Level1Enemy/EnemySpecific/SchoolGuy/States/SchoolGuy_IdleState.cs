
public class SchoolGuy_IdleState : IdleState
{
    private StateSelector _enemy;

    public SchoolGuy_IdleState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName, D_IdleState idleStateData, StateSelector enemy, EnemyLookAroundEntity enemyLookAround, EnemyIdleEntity enemyIdle)
        : base(entityAnimation, stateMachine, animBoolName, idleStateData, enemyLookAround, enemyIdle)
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
        if (IsIdleTimeOver)
        {
            StateMachine.ChangeState(_enemy.PatrolState);
        }
        else if (IsDetectEnemy)
        {
            StateMachine.ChangeState(_enemy.DetectEnemyState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
