using UnityEngine;

public class IdleState : State
{
    protected D_IdleState IdleStateData;
    
    protected EnemyIdleEntity EnemyIdleEntity;

    protected bool IsFlipAfterIdle;
    protected bool IsIdleTimeOver;
    protected bool IsDetectEnemy;

    protected float IdleTime;

    public IdleState(EntityAnimation entityAnimation, FiniteStateMachine stateMachine, string animBoolName,
        D_IdleState idleStateData, EnemyLookAroundEntity enemyLookAround, EnemyIdleEntity enemyIdleEntity)
        : base(entityAnimation, stateMachine, animBoolName)
    {
        this.IdleStateData = idleStateData;
        EntityAnimationAnimation = entityAnimation;
        EnemyIdleEntity = enemyIdleEntity;
    }

    public override void Enter()
    {
        base.Enter();
        EnemyIdleEntity.SetVerticalVelocity(0f);
        IsIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time > StartTime + IdleTime)
        {
            IsIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        IsFlipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        IdleTime = Random.Range(IdleStateData.minIdleTime, IdleStateData.maxIdleTime);
    }
}
