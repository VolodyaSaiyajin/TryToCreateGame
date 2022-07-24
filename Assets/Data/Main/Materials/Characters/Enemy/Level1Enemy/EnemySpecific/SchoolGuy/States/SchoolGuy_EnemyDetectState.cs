
public class SchoolGuy_EnemyDetectState : EnemyDetectState
{
    private StateSelector _enemy;
    private D_EnemyDetectState _detectStateData;
    public SchoolGuy_EnemyDetectState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName, D_EnemyDetectState stateData, StateSelector enemy, EnemyDetectEntity enemyDetectEntity)
        : base(entityAnimation, stateMachine, animBoolName, stateData, enemyDetectEntity)
    {
        this._enemy = enemy;
        _detectStateData = stateData;
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
