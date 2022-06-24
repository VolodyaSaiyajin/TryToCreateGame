using UnityEngine;

public class SchoolGuy : Entity
{
    public SchoolGuy_IdleState IdleState { get; private set; }
    public SchoolGuy_PatrolState MoveState { get; private set; }
    public SchoolGuy_AttackState AttackState { get; private set; }
    public SchoolGuy_EnemyDetectState DetectEnemyState { get; private set; }   

    [SerializeField] private D_IdleState _idleStateData;
    [SerializeField] private D_PatrolState _moveStateData;
    [SerializeField] private D_AttackState _attackStateData;
    [SerializeField] private D_EnemyDetectState _enemyDetectedStateData;

    private PlayerParams _player;

    public int Health { get; private set; }

    public int Damage { get; private set; }

    public SchoolGuy()
    {
        Damage = 10;
        Health = 100;
    }
    public override void Start()
    {
        base.Start();
        IdleState = new SchoolGuy_IdleState(this, stateMachine, "isIdle", _idleStateData, this);
        MoveState = new SchoolGuy_PatrolState(this, stateMachine, "isRun", _moveStateData, this);
        DetectEnemyState = new SchoolGuy_EnemyDetectState(this, stateMachine, "isRun", _enemyDetectedStateData, this);
        AttackState = new SchoolGuy_AttackState(this, stateMachine, "isAttack", _attackStateData, this);
        stateMachine.Intialize(IdleState);
    }
    public override void Update()
    {
        base.Update();
    }    
}
