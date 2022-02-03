using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolGuy : MonoBehaviour, IBandit
{
    [SerializeField] private Rigidbody2D _rb2d;
    private Vector2 _rangeToAttackLeft = new Vector2(-3, 0);
    private RaycastHit2D[] _rangeHits = new RaycastHit2D[1];
    [SerializeField] private SchoolGuyStateMachine _state;
    [SerializeField] private LayerMask _layerMask;

    private Player _player;

    public int Health { get; private set; }

    public int Damage { get; }

    public SchoolGuy()
    {
        Damage = 10;

        Health = 100;
    }


    private void Start()
    {
      _player = GetComponent<Player>();
    }

    void Update()
    {
        CheckRange();
    }

    private void CheckRange()
    {
        var hits = _rb2d.Cast(_rangeToAttackLeft, _rangeHits);

        if (hits > 0)
        {
            _state.DoAttack();
        }
        else
        {
            _state.DoIdle();
        }
    }

    public void ApplyDamage(int damage)
    {
        _player.ApplyDamage(damage);
    }
}
