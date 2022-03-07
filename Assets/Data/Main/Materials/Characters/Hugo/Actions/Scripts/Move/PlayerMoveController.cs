using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : PhysicsMovement
{
    private Vector2 _moveDirection;
    [SerializeField] private float _jumpTakeOffSpeed = 7;
    [SerializeField] private float _maxSpeed = 5;

    private void Start()
    {
        
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = _moveDirection.x;

        if(_moveDirection.y == 1)
        {
            _velocity.y = _jumpTakeOffSpeed;
        } else if (_velocity.y > 0){
            _velocity.y = _velocity.y * .5f;
        }

        _targetVelocity = move * _maxSpeed;
    }


    public void SetJumpDir(float jumpDir)
    {
        _moveDirection.y = jumpDir;
        Debug.Log(jumpDir);
    }

    public void SetMoveDirection(Vector2 moveDir)
    {
        _moveDirection.x = moveDir.x;
        Debug.Log(moveDir.x);
    }
}
