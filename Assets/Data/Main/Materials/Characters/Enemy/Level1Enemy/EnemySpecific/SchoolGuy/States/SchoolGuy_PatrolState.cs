
public class SchoolGuy_PatrolState : PatrolState
{
    private SchoolGuy enemy;

    public SchoolGuy_PatrolState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PatrolState stateData, SchoolGuy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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

        if (isDetectingWall || !isDetectingLedge)
        {            
            enemy.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.IdleState);
        }


        if (isDetectEnemy)
        {
            stateMachine.ChangeState(enemy.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
}
