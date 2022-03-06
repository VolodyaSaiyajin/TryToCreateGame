using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _groundCheckLineSize;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private ContactFilter2D _contactFilter;

    private Vector2 _targetVelocity;
    private Vector2 _jumpDir;
   [SerializeField] private float _gravityModifier;
    private Vector2 _velocity;

    public Vector2 MoveDir => _targetVelocity;

    private readonly RaycastHit2D[] _groundHits = new RaycastHit2D[1];
    private bool _isGround;


    private void FixedUpdate()
    {
        
        Move();
        GroundCheck();
    }

    public void SetMoveDirection(Vector2 moveDir)
    {
        _velocity = moveDir;
    }

    public void SetJumpDir(float jumpDir)
    {
        _velocity.y = jumpDir;
        Debug.Log(jumpDir);
    }

    private void GroundCheck()
    {
        int collisionsCount = _rb2d.Cast(-transform.up, _contactFilter, _groundHits, _groundCheckLineSize);

        if (collisionsCount >= 1)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }

        

    }

   
    private void Move()
    {
        _velocity += _gravityModifier * Time.deltaTime * Physics2D.gravity;

        _targetVelocity = _velocity;

        if (_isGround == true && _velocity.y == 1)
        {
            Jump(_velocity);
        }

        _rb2d.position += new Vector2(_targetVelocity.x * _moveSpeed, _rb2d.velocity.y) * Time.deltaTime;
    }

    private void Jump(Vector2 jumpDir)
    {
        _rb2d.velocity = new Vector2(_targetVelocity.x * _moveSpeed, _rb2d.velocity.y * jumpDir.y);
    }


    private void OnDrawGizmos()
    {
        if (_isGround == true)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _groundCheckLineSize));
    }

}
