using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy1Level : MonoBehaviour, IEnemy1Level
{
    private Player _player;

    public int Health { get; private set; }
    public int Damage { get; }

    [SerializeField] private float _maxDistanceToAttack;
    [SerializeField] private LayerMask _layerMask;

    RaycastHit2D _hitTargetLeft;
    RaycastHit2D _hitTargetRight;
    public Enemy1Level()
    {
        Health = 30;
        Damage = 10;
    }

    

    private void Start()
    {
        _player = GetComponent<Player>(); 
    }


    private void Update()
    {
        CheckDistance();
    }


    private void CheckDistance()
    {
        if (_player != null)
        {
            _hitTargetRight = Physics2D.Raycast(transform.position, transform.right, _maxDistanceToAttack, _layerMask);
            _hitTargetLeft = Physics2D.Raycast(transform.position, transform.right, _maxDistanceToAttack, _layerMask);
        }
    }

    public void Attack()
    {
        _player.ApplyDamage(Damage);
    }

    public void ApplyDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"Enemy health: {Health}");

        if (Health <= 0 && gameObject != null)
        {
            Debug.Log("Enemy is dead");
            Destroy(gameObject);
        }
    }
}
