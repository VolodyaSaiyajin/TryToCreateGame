
public class SchoolGuy_PatrolState : PatrolState
{
    private StateSelector _enemy;

    public SchoolGuy_PatrolState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName,
        D_PatrolState stateData, StateSelector enemy, EnemyLookAround enemyLookAround,
        EnemyPatrolEntity enemyPatrol)
        : base(entityAnimation, stateMachine, animBoolName, stateData, enemy, enemyLookAround, enemyPatrol)
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

        if (IsDetectingWall || !IsDetectingLedge)
        {
            _enemy.IdleState.SetFlipAfterIdle(true);
            StateMachine.ChangeState(_enemy.IdleState);
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
