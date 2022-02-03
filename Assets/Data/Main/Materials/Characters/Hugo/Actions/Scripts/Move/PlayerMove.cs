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

    private Vector2 _moveDir;
    private Vector2 _jumpDir;

    public Vector2 MoveDir => _moveDir;

    private RaycastHit2D[] _groundHits = new RaycastHit2D[1];
    private bool _isGround;


    private void FixedUpdate()
    {
        Move();
        GroundCheck();
    }

    public void SetMoveDirection(Vector2 moveDir)
    {
        _moveDir = moveDir;
    }

    public void SetJumpDir(float jumpDir)
    {

        _jumpDir.y = jumpDir;
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

        if (_jumpDir.y != 0)
        {
            if (_isGround == true)
            {
                Jump(_jumpDir);
            }
        }
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

    private void Move()
    {
        _rb2d.velocity = new Vector3(_moveDir.x * _moveSpeed, _rb2d.velocity.y, transform.position.z);
    }

    private void Jump(Vector2 jumpDir)
    {
        _rb2d.AddForce(jumpDir * _jumpSpeed, ForceMode2D.Impulse);
    }
}
