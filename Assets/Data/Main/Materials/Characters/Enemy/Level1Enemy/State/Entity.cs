using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public int FacingDirection { get; private set; }

    public Rigidbody2D Rb2d { get; private set; }
    public Animator Anim { get; private set; }
    public AliveGO AliveGO { get; private set; }

    private LayerMask _whatIsLayer;

    private Vector2 _velocityWorkspace;

    [SerializeField] private Transform _wallCheckTransform;
    [SerializeField] private Transform _ledgeCheckTransform;

    public virtual void Start()
    {
        FacingDirection = 1;
        stateMachine = new FiniteStateMachine();
        AliveGO = GetComponent<AliveGO>();
        Anim = AliveGO.gameObject.GetComponent<Animator>();
        //TODO: maybe i should have done it differently;
        Rb2d = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
        Rb2d.velocity = new Vector3(_velocityWorkspace.x, Rb2d.velocity.y);
    }

    public virtual void SetVelocityHorizontal(float velocity)
    {
        _velocityWorkspace.Set(FacingDirection * velocity, Rb2d.velocity.y * 0);

    }

    public virtual bool CheckColliderHorizontal()
    {
        if (FacingDirection == 1)
        {
            //TODO: for debugg
            _whatIsLayer = entityData.WhatIsTouched;
            return Physics2D.Raycast(_wallCheckTransform.position, Vector2.right, entityData.WallCheckDistance, entityData.WhatIsTouched);
        }
        else if (FacingDirection == -1)
        {
            _whatIsLayer = entityData.WhatIsTouched;
            return Physics2D.Raycast(_wallCheckTransform.position, -Vector2.right, entityData.WallCheckDistance, entityData.WhatIsTouched);
        }
        return false;
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(_ledgeCheckTransform.position, Vector2.down, entityData.LedgeCheckDistance, entityData.WhatIsGround);
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        AliveGO.transform.Rotate(0f, 180f, 0);
    }

    public virtual bool CheckEnemy()
    {
        if (FacingDirection == 1)
        {
            return Physics2D.Raycast(_ledgeCheckTransform.position, Vector2.right, entityData.VisibilityRange, entityData.WhatIsEnemy);
        }
        else if (FacingDirection == -1)
        {
            return Physics2D.Raycast(_ledgeCheckTransform.position, -Vector2.right, entityData.VisibilityRange, entityData.WhatIsEnemy);
        }
        return false;
    }

    public virtual void ApplyDamage(int damage)
    {
        entityData.Heath -= damage;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(_wallCheckTransform.position, _wallCheckTransform.position + (Vector3)(entityData.WallCheckDistance * FacingDirection * Vector2.right));
        Gizmos.DrawLine(_ledgeCheckTransform.position, _ledgeCheckTransform.position + (Vector3)(Vector2.down * entityData.LedgeCheckDistance));
        Gizmos.DrawLine(_ledgeCheckTransform.position, _ledgeCheckTransform.position + (Vector3)(entityData.VisibilityRange * FacingDirection * Vector2.right));
    }
}
