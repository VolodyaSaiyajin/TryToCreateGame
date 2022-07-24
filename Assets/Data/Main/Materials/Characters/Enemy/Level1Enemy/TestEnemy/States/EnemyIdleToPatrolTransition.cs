using UnityEngine;

public class EnemyIdleToPatrolTransition : Transition
{
    [SerializeField] private D_IdleState _idleStateData;

    private float _startTime;
    private float _idleTime;

    private void Start()
    {
        SetRandomIdleTime();
    }

    private void Update()
    {
        CountIdleTime();
    }

    private void CountIdleTime()
    {
        if (Time.time > _startTime + _idleTime)
        {
            IsNeedTransition = true;
        }
        Debug.Log(IsNeedTransition);
    }

    private void SetRandomIdleTime()
    {
        _idleTime = Random.Range(_idleStateData.MinIdleTime, _idleStateData.MaxIdleTime);
    }

    public override void Enable()
    {
        _startTime = Time.time;
    }
}
