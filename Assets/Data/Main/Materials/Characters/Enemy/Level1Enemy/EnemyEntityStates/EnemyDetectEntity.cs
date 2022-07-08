using UnityEngine;
using UnityEngine.Events;

public class EnemyDetectEntity : EnemyEntity
{
    [SerializeField] private UnityEvent _notLooked;

    public event UnityAction NotLooked
    {
        add => _notLooked.AddListener(value);
        remove => _notLooked.RemoveListener(value);
    }

    public override void Start()
    {
        base.Start();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void SetVerticalVelocity(float velocity)
    {
        base.SetVerticalVelocity(velocity);
    }

    public virtual void FollowForPlayer()
    {
        if (AngleFacingDirection >= AngleRight)
            _notLooked.Invoke(); //Flip
    }
}
