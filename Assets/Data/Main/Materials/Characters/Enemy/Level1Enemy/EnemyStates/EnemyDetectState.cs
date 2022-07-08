
public class EnemyDetectState : State
{
    protected PlayerEntity PlayerEntity;
    protected EnemyDetectEntity Enemy;
    protected D_EnemyDetectState StateData;

    public EnemyDetectState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName, D_EnemyDetectState stateData,EnemyDetectEntity enemy)
        : base(entityAnimation, stateMachine, animBoolName)
    {
        Enemy = enemy;
        this.StateData = stateData;
        this.EntityAnimationAnimation = entityAnimation;
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
