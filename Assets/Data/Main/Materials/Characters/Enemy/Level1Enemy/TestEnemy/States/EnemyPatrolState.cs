using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    private Animator _animator;
    private string _animBoolName = "isRun";

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetBool(_animBoolName, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(_animBoolName, false);
    }

    private void Update()
    {
        MoveVertical();
    }

    private void MoveVertical()
    {

    }
}
