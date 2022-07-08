public class PatrolState : State
{
    protected D_PatrolState StateData;
    protected EnemyPatrolEntity EnemyPatrol;
    protected EnemyLookAroundEntity EnemyLookAround;

    protected bool IsDetectingWall;
    protected bool IsDetectingLedge;
    protected bool IsDetectEnemy;

    public PatrolState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName,
        D_PatrolState stateData, StateSelector stateSelector, EnemyLookAroundEntity enemyLookAround, EnemyPatrolEntity enemyPatrol)
        : base(entityAnimation, stateMachine, animBoolName)
    {
        StateData = stateData;
        EnemyLookAround = enemyLookAround;
        EnemyPatrol = enemyPatrol;
    }

    public override void Enter()
    {
        base.Enter();
        EnemyPatrol.SetVerticalVelocity(StateData.movementSpeed);

        IsDetectingLedge = EnemyLookAround.CheckLedge();
        IsDetectingWall = EnemyLookAround.CheckColliderHorizontal();
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
        IsDetectingLedge = EnemyLookAround.CheckLedge();
        IsDetectingWall = EnemyLookAround.CheckColliderHorizontal();
        IsDetectEnemy = EnemyLookAround.IsSeeEnemy();
    }
}
