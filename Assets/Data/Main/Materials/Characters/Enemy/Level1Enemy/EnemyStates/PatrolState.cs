public class PatrolState : State
{
    protected D_PatrolState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isDetectEnemy;

    public PatrolState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PatrolState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocityHorizontal(stateData.movementSpeed);

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckColliderHorizontal();
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
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckColliderHorizontal();
        isDetectEnemy = entity.CheckEnemy();

    }
}
