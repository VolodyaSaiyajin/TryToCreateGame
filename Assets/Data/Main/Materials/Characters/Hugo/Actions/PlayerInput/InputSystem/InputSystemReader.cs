using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemReader : MonoBehaviour
{
    [SerializeField] private PlayerMoveController _plyaerMoveContoller;
    [SerializeField] private PlayerAttack _playerAttack;

    private InputSystem _inputActions;

    private float _buttonAttackValue;
    private Vector2 _buttonMoveValue;
    public float ButtonAttackValue => _buttonAttackValue;
    public float ButtonMoveValue => _buttonMoveValue.x;

    private void Awake()
    {
        _inputActions = new InputSystem();
        _inputActions.Player.Move.performed += OnHorizontalMovement;
        _inputActions.Player.Move.canceled += OnHorizontalMovement;

        _inputActions.Player.Jump.started += OnJump;        
        _inputActions.Player.Jump.canceled += OnJump;

        _inputActions.Player.Attack.started += OnAttack;
        _inputActions.Player.Attack.canceled += OnAttack;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }


    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _buttonAttackValue = context.ReadValue<float>();
            _playerAttack.SetButtonValue(_buttonAttackValue);
        }
        
    }

    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        _buttonMoveValue = context.ReadValue<Vector2>();
        _plyaerMoveContoller.SetMoveDirection(_buttonMoveValue);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
       float dirY = context.ReadValue<float>();
        _plyaerMoveContoller.SetJumpDir(dirY);
    }
}
