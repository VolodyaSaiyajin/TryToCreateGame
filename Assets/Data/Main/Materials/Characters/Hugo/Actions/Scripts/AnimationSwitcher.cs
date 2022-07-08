using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    private Animator _animator;
    private PlayerAttack _playerAttack;
    private InputSystemReader _inputSystemReader;

    private void Awake()
    {
        _inputSystemReader = GetComponent<InputSystemReader>(); 
        _playerAttack = GetComponent<PlayerAttack>(); 
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    } 

    private void Update()
    {
        SwitchAnimation();
    }
    private void SwitchAnimation()
    {
        if(_playerAttack.CurrentAttackState)
        {
            _animator.SetBool("isAttack", true);
            _animator.SetFloat("attackSpeed", _playerAttack.AttackDelay);
        }
        else
        {
            _animator.SetBool("isAttack", false);
        }

        if (_inputSystemReader.ButtonMoveValue > 0 || _inputSystemReader.ButtonMoveValue < 0)
        {
            _animator.SetBool("isIdle", false);
            _animator.SetBool("isRacing", true);
            _animator.SetBool("isRunning", true);
        }
        else if(_inputSystemReader.ButtonMoveValue == 0)
        {
            _animator.SetBool("isIdle", false);
            _animator.SetBool("isRacing", false);
            _animator.SetBool("isRunning", false);
        }

        if (_inputSystemReader.ButtonMoveValue < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (_inputSystemReader.ButtonMoveValue > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
