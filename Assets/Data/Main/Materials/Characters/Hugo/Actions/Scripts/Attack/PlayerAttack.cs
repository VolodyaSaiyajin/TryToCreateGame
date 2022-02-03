using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public float CurrentAttackDelay => _currentAttackDelay;
    public bool CurrentAttackState => _isAttack;

    private Rigidbody2D _rb2d;

    [Header("Set target and damage")]
    [SerializeField] private BanditEnemy _banditEnemy;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _maxDistanceToAttack;
    [SerializeField] private float _attackDelay;
    [SerializeField] private LayerMask _layerMask;

    [Header("Set hand point")]
    [SerializeField] private Transform _handPoint;
    [SerializeField] private float _heightHand;

    // attack settings
    private bool _canTouch;
    private bool _isAttack;
    private float _currentAttackDelay;
    RaycastHit2D _hitTargetLeft;
    RaycastHit2D _hitTargetRight;


    private void Start()
    {
    }

    private void Update()
    {
        ÑheckDistance();
        TryAttack(_attackDelay);
    }
    private void ÑheckDistance()
    {
        
        _hitTargetRight = Physics2D.Raycast(_handPoint.transform.position, _handPoint.transform.right, _maxDistanceToAttack, _layerMask);
        _hitTargetLeft = Physics2D.Raycast(_handPoint.transform.position, -_handPoint.transform.right, _maxDistanceToAttack, _layerMask);

        if (_hitTargetRight || _hitTargetLeft)
        {
            _canTouch = true;
        }
        else
        {
            _canTouch = false;
        }
    }

    public void SetButtonValue(float buttonValue)
    {
        if (buttonValue == 1)
        {
            _isAttack = true;
        }
    }
    private void TryAttack(float delay)
    {
        if (_currentAttackDelay >= 0f && _currentAttackDelay <= delay)
        {
            _isAttack = false;
            _currentAttackDelay += Time.deltaTime;
        }
        else if (_canTouch && _isAttack && _banditEnemy)
        {
            _hitTargetRight.collider.TryGetComponent(out IEnemy1Level enemy);
            enemy.ApplyDamage(_damage);
            _currentAttackDelay = 0f;
        }
        else if (_currentAttackDelay >= delay && _isAttack)
        {
            _currentAttackDelay = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        if (_canTouch)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        if (transform.eulerAngles.y == 0)
        {
            Gizmos.DrawLine(_handPoint.position, new Vector3(_handPoint.position.x + _maxDistanceToAttack, _handPoint.position.y));
        }
        else if (transform.eulerAngles.y == 180)
        {
            Gizmos.DrawLine(_handPoint.position, new Vector3(_handPoint.position.x - _maxDistanceToAttack, _handPoint.position.y));
        }
    }
}
