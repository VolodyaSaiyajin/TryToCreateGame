
public class SchoolGuy_IdleState : IdleState
{
    private StateSelector _stateSelector;

    public SchoolGuy_IdleState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName, D_IdleState idleStateData, StateSelector stateSelector, EnemyLookAround enemyLookAround, EnemyIdleEntity enemyIdle)
        : base(entityAnimation, stateMachine, animBoolName, idleStateData, enemyLookAround, enemyIdle)
    {
        _stateSelector = stateSelector;
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
