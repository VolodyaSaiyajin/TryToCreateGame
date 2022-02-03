using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditEnemy : MonoBehaviour, IEnemy1Level
{
    public int Health { get; private set; }
    public int Damage { get; }

    private float _maxDistanceToAttack = 4;
    private bool _canSee;
    private RaycastHit2D _hit;
    public BanditEnemy()
    {
        Damage = 30;
        Health = 100;
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


    private void CheckDistanceBetweenCharacter()
    {
        _hit = Physics2D.Raycast(transform.position, transform.right, _maxDistanceToAttack);
    }



    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    private void OnDrawGizmos()
    {
        if (_canSee)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        if (transform.eulerAngles.y == 0)
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + _maxDistanceToAttack, transform.position.y));
        }
        else if (transform.eulerAngles.y == 180)
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - _maxDistanceToAttack, transform.position.y));
        }
    }

}