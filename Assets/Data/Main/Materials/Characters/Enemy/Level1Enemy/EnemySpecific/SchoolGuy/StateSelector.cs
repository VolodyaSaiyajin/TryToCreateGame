using UnityEngine;

public class StateSelector : EnemyEntity
{
    [SerializeField] private D_IdleState _idleStateData;
    [SerializeField] private D_PatrolState _patrolStateData;
    [SerializeField] private D_AttackState _attackStateData;
    [SerializeField] private D_EnemyDetectState _enemyDetectState;
    [SerializeField] private D_EntityVisibility _entityVisibility;

    public SchoolGuy_IdleState IdleState { get; private set; }
    public SchoolGuy_PatrolState PatrolState { get; private set; }
    public SchoolGuy_AttackState AttackState { get; private set; }
    public SchoolGuy_EnemyDetectState DetectEnemyState { get; private set; }

    public int Damage { get; private set; }

    public StateSelector(D_IdleState idleStateData, D_PatrolState patrolStateData, D_AttackState attackStateData, D_EnemyDetectState enemyDetectState, D_EntityVisibility entityVisibility)
    {
        _idleStateData = idleStateData;
        _patrolStateData = patrolStateData;
        _attackStateData = attackStateData;
        _enemyDetectState = enemyDetectState;
        _entityVisibility = entityVisibility;

    }
    
    public override void Start()
    {
        base.Start();

        IdleState = new SchoolGuy_IdleState(EntityAnimation, StateMachine, "isIdle", _idleStateData, this, EnemyLookAround, EnemyIdle);
        
        PatrolState = new SchoolGuy_PatrolState(EntityAnimation, StateMachine, "isRun", _patrolStateData, this, EnemyLookAround, EnemyPatrol);

        DetectEnemyState = new SchoolGuy_EnemyDetectState(EntityAnimation, StateMachine, "isRun", _enemyDetectState, this, EnemyDetect);

        AttackState = new SchoolGuy_AttackState(EntityAnimation, StateMachine, "isAttack", _attackStateData, this);

        StateMachine.InitializeState(IdleState);
    }

    public override void Update()
    {
        base.Update();
    }
}
